using GenteFit.Controllers;
using GenteFit.Data;
using GenteFit.Models;
using GenteFit.Utils;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ClosedXML.Excel.XLPredefinedFormat;

namespace GenteFit
{
    public partial class Form1 : Form
    {
        private readonly ClientesController clientesController = new ClientesController();
        private readonly ProductosController productosController = new ProductosController();
        private readonly ActividadesController actividadesController = new ActividadesController();
        private readonly SesionesController sesionesController = new SesionesController();
        private readonly ReservasController reservasController = new ReservasController();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // cargar inicial
            CargarClientes();
            CargarProductos();
            CargarActividades();
            CargarSesiones();

            // poblar combos
            RefreshClientesCombo();
            RefreshActividadesCombo();

            // configurar sort auto
            foreach (DataGridViewColumn col in dgvClientes.Columns) col.SortMode = DataGridViewColumnSortMode.Automatic;
            foreach (DataGridViewColumn col in dgvProductos.Columns) col.SortMode = DataGridViewColumnSortMode.Automatic;
            foreach (DataGridViewColumn col in dgvActividades.Columns) col.SortMode = DataGridViewColumnSortMode.Automatic;
            foreach (DataGridViewColumn col in dgvSesiones.Columns) col.SortMode = DataGridViewColumnSortMode.Automatic;
        }

        // ----------------------------
        // CLIENTES
        // ----------------------------
        private void CargarClientes()
        {
            var lista = clientesController.Buscar(""); // todos activos
            dgvClientes.DataSource = lista;
            lblTotalClientsLabel.Text = $"Total clientes: {lista.Count}";
            RefreshClientesCombo();
        }

        private void RefreshClientesCombo()
        {
            var list = clientesController.Buscar("");
            cmbReservasCliente.DataSource = null;
            cmbReservasCliente.DataSource = list;
            cmbReservasCliente.DisplayMember = "Nombre";
            cmbReservasCliente.ValueMember = "Id";
        }

        private void btnAltaCliente_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreCliente.Text) || string.IsNullOrWhiteSpace(txtDocumentoCliente.Text))
            {
                MessageBox.Show("Nombre y DNI/NIF son obligatorios.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            clientesController.Registrar(
                txtNombreCliente.Text.Trim(),
                txtApellidosCliente.Text.Trim(),
                txtDocumentoCliente.Text.Trim(),
                txtEmailCliente.Text.Trim(),
                txtTelefonoCliente.Text.Trim()
            );

            CargarClientes();
            MessageBox.Show("Cliente registrado.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnModificarCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) return;
            int id = (int)dgvClientes.SelectedRows[0].Cells["Id"].Value;

            clientesController.Editar(
                id,
                txtNombreCliente.Text.Trim(),
                txtApellidosCliente.Text.Trim(),
                txtDocumentoCliente.Text.Trim(),
                txtEmailCliente.Text.Trim(),
                txtTelefonoCliente.Text.Trim()
            );

            CargarClientes();
        }

        private void btnBajaCliente_Click(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) return;
            int id = (int)dgvClientes.SelectedRows[0].Cells["Id"].Value;
            string nombre = dgvClientes.SelectedRows[0].Cells["Nombre"].Value?.ToString();

            var confirm = MessageBox.Show($"¿Dar de baja al cliente \"{nombre}\"?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                clientesController.Bajar(id);
                CargarClientes();
            }
        }

        private void txtBuscarCliente_TextChanged(object sender, EventArgs e)
        {
            var q = txtBuscarCliente.Text.Trim();
            dgvClientes.DataSource = clientesController.Buscar(q);
        }

        private void dgvClientes_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvClientes.SelectedRows.Count == 0) return;
            var row = dgvClientes.SelectedRows[0];
            txtNombreCliente.Text = row.Cells["Nombre"].Value?.ToString();
            txtApellidosCliente.Text = row.Cells["Apellidos"].Value?.ToString();
            txtDocumentoCliente.Text = row.Cells["Documento"].Value?.ToString();
            txtEmailCliente.Text = row.Cells["Email"].Value?.ToString();
            txtTelefonoCliente.Text = row.Cells["Telefono"].Value?.ToString();
        }

        private void btnLimpiarCliente_Click(object sender, EventArgs e)
        {
            txtNombreCliente.Clear();
            txtApellidosCliente.Clear();
            txtDocumentoCliente.Clear();
            txtEmailCliente.Clear();
            txtTelefonoCliente.Clear();
            txtBuscarCliente.Clear();
            dgvClientes.ClearSelection();
        }

        private void btnImportarExcelClientes_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel (*.xlsx)|*.xlsx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lista = ExcelImporter.ImportClientes(ofd.FileName); // reusa importer
                        foreach (var c in lista)
                        {
                            clientesController.Registrar(c.Nombre, c.Apellidos ?? "", c.Documento ?? "", c.Email ?? "", "");
                        }
                        CargarClientes();
                        MessageBox.Show($"Importados {lista.Count} clientes.", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportarExcelClientes_Click(object sender, EventArgs e)
        {
            var lista = clientesController.Buscar("");
            if (lista.Count == 0)
            {
                MessageBox.Show("No hay clientes para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.FileName = "clientes.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExcelExporter.ExportClientes(sfd.FileName, lista.Select(c => new GenteFit.Models.Cliente
                    {
                        Nombre = c.Nombre + " " + (c.Apellidos ?? ""),
                        Email = c.Email,
                        FechaAlta = System.DateTime.UtcNow
                    }).ToList());
                    MessageBox.Show("Clientes exportados.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void dgvClientes_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var lista = clientesController.Buscar("");
            string col = dgvClientes.Columns[e.ColumnIndex].DataPropertyName;
            if (dgvClientes.Tag == null || (string)dgvClientes.Tag == "DESC")
            {
                dgvClientes.DataSource = lista.OrderBy(x => x.GetType().GetProperty(col).GetValue(x, null)).ToList();
                dgvClientes.Tag = "ASC";
            }
            else
            {
                dgvClientes.DataSource = lista.OrderByDescending(x => x.GetType().GetProperty(col).GetValue(x, null)).ToList();
                dgvClientes.Tag = "DESC";
            }
            lblTotalClientsLabel.Text = $"Total clientes: {lista.Count}";
        }

        // ----------------------------
        // PRODUCTOS
        // ----------------------------
        private void CargarProductos()
        {
            var lista = productosController.Listar();
            dgvProductos.DataSource = lista;
            lblTotalProductsLabel.Text = $"Total productos: {lista.Count}";
        }

        private void btnAltaProducto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreProducto.Text) || string.IsNullOrWhiteSpace(txtPrecioProducto.Text)) return;
            if (!decimal.TryParse(txtPrecioProducto.Text, out decimal precio)) { MessageBox.Show("Precio inválido"); return; }
            productosController.Alta(txtNombreProducto.Text.Trim(), precio);
            CargarProductos();
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;
            int id = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
            if (!decimal.TryParse(txtPrecioProducto.Text, out decimal precio)) { MessageBox.Show("Precio inválido"); return; }
            productosController.Modificar(id, txtNombreProducto.Text.Trim(), precio);
            CargarProductos();
        }

        private void btnBajaProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;
            int id = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
            string nombre = dgvProductos.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            var confirm = MessageBox.Show($"¿Eliminar producto {nombre}?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm == DialogResult.Yes)
            {
                productosController.Baja(id);
                CargarProductos();
            }
        }

        private void btnLimpiarProducto_Click(object sender, EventArgs e)
        {
            txtBuscarProducto.Text = "";
            txtNombreProducto.Text = "";
            txtPrecioProducto.Text = "";
            dgvProductos.ClearSelection();
        }

        private void btnImportarExcelProductos_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel (*.xlsx)|*.xlsx";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lista = ExcelImporter.ImportProductos(ofd.FileName);
                        foreach (var p in lista) productosController.Alta(p.Nombre, p.Precio);
                        CargarProductos();
                        MessageBox.Show($"Importados {lista.Count} productos.", "Importación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error importando: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportarExcelProductos_Click(object sender, EventArgs e)
        {
            var lista = productosController.Listar();
            if (lista.Count == 0) { MessageBox.Show("No hay productos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information); return; }
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.FileName = "productos.xlsx";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    ExcelExporter.ExportProductos(sfd.FileName, lista);
                    MessageBox.Show("Exportado productos.", "Exportar", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            var q = txtBuscarProducto.Text.Trim().ToLower();
            dgvProductos.DataSource = productosController.Listar().Where(p => p.Nombre.ToLower().Contains(q) || p.Precio.ToString().Contains(q)).ToList();
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;
            txtNombreProducto.Text = dgvProductos.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            txtPrecioProducto.Text = dgvProductos.SelectedRows[0].Cells["Precio"].Value?.ToString();
        }

        private void dgvProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var lista = productosController.Listar();
            string col = dgvProductos.Columns[e.ColumnIndex].DataPropertyName;

            if (dgvProductos.Tag == null || (string)dgvProductos.Tag == "DESC")
            {
                dgvProductos.DataSource = lista.OrderBy(x =>
                    x.GetType().GetProperty(col).GetValue(x, null)).ToList();
                dgvProductos.Tag = "ASC";
            }
            else
            {
                dgvProductos.DataSource = lista.OrderByDescending(x =>
                    x.GetType().GetProperty(col).GetValue(x, null)).ToList();
                dgvProductos.Tag = "DESC";
            }

            lblTotalProductsLabel.Text = $"Total productos: {lista.Count}";
        }

        // ----------------------------
        // ACTIVIDADES
        // ----------------------------
        private void CargarActividades()
        {
            var list = actividadesController.Listar();
            dgvActividades.DataSource = list;
            // fill intensity combo is done in designer
            RefreshActivitiesInSesions();
        }

        private void btnAltaActividad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombreActividad.Text)) { MessageBox.Show("Nombre requerido"); return; }
            var intensidad = (GenteFit.Models.Intensidad)Enum.Parse(typeof(GenteFit.Models.Intensidad), cmbIntensidadActividad.SelectedItem?.ToString() ?? "Media");
            actividadesController.Crear(txtNombreActividad.Text.Trim(), txtDescripcionActividad.Text.Trim(), intensidad);
            CargarActividades();
        }

        private void btnModificarActividad_Click(object sender, EventArgs e)
        {
            if (dgvActividades.SelectedRows.Count == 0) return;
            int id = (int)dgvActividades.SelectedRows[0].Cells["Id"].Value;
            var intensidad = (GenteFit.Models.Intensidad)Enum.Parse(typeof(GenteFit.Models.Intensidad), cmbIntensidadActividad.SelectedItem?.ToString() ?? "Media");
            actividadesController.Editar(id, txtNombreActividad.Text.Trim(), txtDescripcionActividad.Text.Trim(), intensidad);
            CargarActividades();
        }

        private void btnBajaActividad_Click(object sender, EventArgs e)
        {
            // no DAO for delete implemented earlier; reuse ActividadDAO if added
            if (dgvActividades.SelectedRows.Count == 0) return;
            MessageBox.Show("Eliminar actividad: implemente método en ActividadDAO si desea borrado físico.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvActividades_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvActividades.SelectedRows.Count == 0) return;
            txtNombreActividad.Text = dgvActividades.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            txtDescripcionActividad.Text = dgvActividades.SelectedRows[0].Cells["Descripcion"].Value?.ToString();
            var intens = dgvActividades.SelectedRows[0].Cells["Intensidad"].Value?.ToString();
            if (!string.IsNullOrEmpty(intens)) cmbIntensidadActividad.SelectedItem = intens;
        }

        private void btnLimpiarActividad_Click(object sender, EventArgs e)
        {
            txtNombreActividad.Clear();
            txtDescripcionActividad.Clear();
            cmbIntensidadActividad.SelectedIndex = -1;
            dgvActividades.ClearSelection();
        }

        private void RefreshActivitiesInSesions()
        {
            var acts = actividadesController.Listar();
            cmbActividadSesion.DataSource = null;
            cmbActividadSesion.DataSource = acts;
            cmbActividadSesion.DisplayMember = "Nombre";
            cmbActividadSesion.ValueMember = "Id";

            cmbIntensidadActividad.SelectedIndex = 1; // default Media
        }

        // ----------------------------
        // SESIONES
        // ----------------------------
        private void CargarSesiones()
        {
            var list = sesionesController.ListarProximas();
            dgvSesiones.DataSource = list.Select(s => new
            {
                s.Id,
                Actividad = s.Actividad?.Nombre ?? actividadesController.Listar().FirstOrDefault(a => a.Id == s.ActividadId)?.Nombre,
                FechaHora = s.FechaHora,
                s.Sala,
                s.Monitor,
                s.AforoMax
            }).ToList();
            RefreshSessionsReservationViews();
        }

        private void RefreshSessionsReservationViews()
        {
            // sessions list for reservation tab
            var list = sesionesController.ListarProximas();
            dgvReservasSesiones.DataSource = list.Select(s => new { s.Id, Actividad = s.Actividad?.Nombre ?? "", FechaHora = s.FechaHora, s.Sala, s.Monitor, s.AforoMax }).ToList();
        }

        private void btnAltaSesion_Click(object sender, EventArgs e)
        {
            if (cmbActividadSesion.SelectedItem == null) { MessageBox.Show("Seleccione actividad"); return; }
            var actividadId = (int)cmbActividadSesion.SelectedValue;
            var fecha = dtpFechaSesion.Value.Date + dtpHoraSesion.Value.TimeOfDay;
            sesionesController.Programar(actividadId, fecha, txtSalaSesion.Text.Trim(), txtMonitorSesion.Text.Trim(), (int)numAforoSesion.Value);
            CargarSesiones();
            MessageBox.Show("Sesión creada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void dgvSesiones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSesiones.SelectedRows.Count == 0) return;
            var id = (int)dgvSesiones.SelectedRows[0].Cells["Id"].Value;
            var s = sesionesController.GetById(id);
            if (s == null) return;
            cmbActividadSesion.SelectedValue = s.ActividadId;
            dtpFechaSesion.Value = s.FechaHora;
            dtpHoraSesion.Value = s.FechaHora;
            txtSalaSesion.Text = s.Sala;
            txtMonitorSesion.Text = s.Monitor;
            numAforoSesion.Value = s.AforoMax;
        }

        private void btnModificarSesion_Click(object sender, EventArgs e)
        {
            if (dgvSesiones.SelectedRows.Count == 0) return;
            int id = (int)dgvSesiones.SelectedRows[0].Cells["Id"].Value;
            var sesión = sesionesController.GetById(id);
            if (sesión == null) return;
            sesión.FechaHora = dtpFechaSesion.Value.Date + dtpHoraSesion.Value.TimeOfDay;
            sesión.Sala = txtSalaSesion.Text.Trim();
            sesión.Monitor = txtMonitorSesion.Text.Trim();
            sesión.AforoMax = (int)numAforoSesion.Value;
            sesionesController.Editar(sesión);
            CargarSesiones();
        }

        private void btnBajaSesion_Click(object sender, EventArgs e)
        {
            if (dgvSesiones.SelectedRows.Count == 0) return;
            int id = (int)dgvSesiones.SelectedRows[0].Cells["Id"].Value;
            // no delete method implemented in SesionDAO earlier; if you want implement Delete
            MessageBox.Show("Eliminar sesión: implemente método de borrado en SesionDAO si desea borrar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnLimpiarSesion_Click(object sender, EventArgs e)
        {
            cmbActividadSesion.SelectedIndex = -1;
            txtSalaSesion.Clear();
            txtMonitorSesion.Clear();
            numAforoSesion.Value = Sesion.CAPACITY_DEFAULT;
            dgvSesiones.ClearSelection();
        }

        // ----------------------------
        // RESERVAS
        // ----------------------------
        private void dgvReservasSesiones_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvReservasSesiones.SelectedRows.Count == 0)
            {
                dgvReservasConfirmed.DataSource = null;
                dgvReservasWaiting.DataSource = null;
                txtReservasSesionId.Clear();
                return;
            }

            int sesionId = (int)dgvReservasSesiones.SelectedRows[0].Cells["Id"].Value;
            txtReservasSesionId.Text = sesionId.ToString();

            var estado = reservasController.EstadoDeSesion(sesionId);
            dgvReservasConfirmed.DataSource = estado.confirmed.Select(r => new { r.Id, Cliente = r.Cliente?.Nombre ?? clientesController.GetById(r.ClienteId)?.Nombre, r.CreatedAt }).ToList();
            dgvReservasWaiting.DataSource = estado.waiting.Select(r => new { r.Id, Pos = r.PosicionEspera, Cliente = r.Cliente?.Nombre ?? clientesController.GetById(r.ClienteId)?.Nombre, r.CreatedAt }).ToList();
        }

        private void btnReservar_Click(object sender, EventArgs e)
        {
            if (cmbReservasCliente.SelectedItem == null) { MessageBox.Show("Seleccione cliente"); return; }
            if (string.IsNullOrWhiteSpace(txtReservasSesionId.Text)) { MessageBox.Show("Seleccione sesión"); return; }

            int clienteId = (int)cmbReservasCliente.SelectedValue;
            int sesionId = int.Parse(txtReservasSesionId.Text);

            try
            {
                var r = reservasController.Reservar(clienteId, sesionId);
                if (r.Estado == EstadoReserva.Confirmada)
                    MessageBox.Show("Reserva confirmada.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show($"Añadido a lista de espera. Posición: {r.PosicionEspera}", "Lista de espera", MessageBoxButtons.OK, MessageBoxIcon.Information);

                dgvReservasSesiones_SelectionChanged(null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al reservar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancelarReserva_Click(object sender, EventArgs e)
        {
            if (cmbReservasCliente.SelectedItem == null) { MessageBox.Show("Seleccione cliente"); return; }
            if (string.IsNullOrWhiteSpace(txtReservasSesionId.Text)) { MessageBox.Show("Seleccione sesión"); return; }

            int clienteId = (int)cmbReservasCliente.SelectedValue;
            int sesionId = int.Parse(txtReservasSesionId.Text);

            var confirm = MessageBox.Show("¿Cancelar reserva?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            reservasController.AnularReserva(clienteId, sesionId);
            MessageBox.Show("Reserva anulada. Si había lista de espera, se ha promovido al primero.", "OK", MessageBoxButtons.OK, MessageBoxIcon.Information);
            dgvReservasSesiones_SelectionChanged(null, null);
        }

        // ----------------------------
        // Helpers
        // ----------------------------
        private void RefreshActividadesCombo()
        {
            var acts = actividadesController.Listar();
            cmbActividadSesion.DataSource = null;
            cmbActividadSesion.DataSource = acts;
            cmbActividadSesion.DisplayMember = "Nombre";
            cmbActividadSesion.ValueMember = "Id";
        }
    }
}
