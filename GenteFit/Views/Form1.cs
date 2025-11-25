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

namespace GenteFit
{
    public partial class Form1 : Form
    {
        private readonly SociosController controller = new SociosController();
        private readonly ProductosController productosController = new ProductosController();

        //
        // Eventos Socios
        //
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarSocios();
            CargarProductos();

            foreach (DataGridViewColumn col in dgvSocios.Columns)
                col.SortMode = DataGridViewColumnSortMode.Automatic;

            foreach (DataGridViewColumn col in dgvProductos.Columns)
                col.SortMode = DataGridViewColumnSortMode.Automatic;
        }

        private void CargarSocios()
        {
            var lista = controller.Listar();
            dgvSocios.DataSource = lista;
            lblTotalSocios.Text = $"Total socios: {lista.Count}";
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (txtNombre.Text == "" || txtEmail.Text == "") return;
            controller.Alta(txtNombre.Text, txtEmail.Text);
            CargarSocios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 0) return;
            int id = (int)dgvSocios.SelectedRows[0].Cells["Id"].Value;
            controller.Modificar(id, txtNombre.Text, txtEmail.Text);
            CargarSocios();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 0) return;

            int id = (int)dgvSocios.SelectedRows[0].Cells["Id"].Value;
            string nombre = dgvSocios.SelectedRows[0].Cells["Nombre"].Value.ToString();

            var confirm = MessageBox.Show(
                $"¿Seguro que deseas eliminar al socio \"{nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                controller.Baja(id);
                CargarSocios();
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarSocios();
        }

        private void btnImportarExcelSocios_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel (*.xlsx)|*.xlsx";
                ofd.Title = "Importar socios desde Excel";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lista = ExcelImporter.ImportSocios(ofd.FileName);

                        foreach (var socio in lista)
                            controller.Alta(socio.Nombre, socio.Email);

                        CargarSocios();

                        MessageBox.Show($"Se han importado {lista.Count} socios.", "Importación completada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al importar socios: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportarExcelSocios_Click(object sender, EventArgs e)
        {
            var lista = controller.Listar();
            if (lista.Count == 0)
            {
                MessageBox.Show("No hay socios para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.Title = "Guardar listado de socios";
                sfd.FileName = "socios.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExporter.ExportSocios(sfd.FileName, lista);

                        MessageBox.Show(
                            $"Socios exportados correctamente a:\n{sfd.FileName}",
                            "Exportación completada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar socios: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBuscarSocio_TextChanged(object sender, EventArgs e)
        {
            var texto = txtBuscarSocio.Text.ToLower();
            dgvSocios.DataSource = controller.Listar()
                .Where(s => s.Nombre.ToLower().Contains(texto)
                         || s.Email.ToLower().Contains(texto))
                .ToList();
        }

        private void btnLimpiarSocio_Click(object sender, EventArgs e)
        {
            txtNombre.Text = "";
            txtEmail.Text = "";
            txtBuscarSocio.Text = "";
            dgvSocios.ClearSelection();
        }
        private void dgvSocios_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var lista = controller.Listar();

            // Nombre de la columna
            string col = dgvSocios.Columns[e.ColumnIndex].DataPropertyName;

            // Orden alternando asc/desc
            if (dgvSocios.Tag == null || (string)dgvSocios.Tag == "DESC")
            {
                dgvSocios.DataSource = lista.OrderBy(x => x.GetType().GetProperty(col).GetValue(x, null)).ToList();
                dgvSocios.Tag = "ASC";
            }
            else
            {
                dgvSocios.DataSource = lista.OrderByDescending(x => x.GetType().GetProperty(col).GetValue(x, null)).ToList();
                dgvSocios.Tag = "DESC";
            }

            lblTotalSocios.Text = $"Total socios: {lista.Count}";
        }

        private void dgvSocios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 0) return;
            txtNombre.Text = dgvSocios.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            txtEmail.Text = dgvSocios.SelectedRows[0].Cells["Email"].Value?.ToString();
        }

        //
        // Eventos Productos
        //
        private void CargarProductos()
        {
            var lista = productosController.Listar();
            dgvProductos.DataSource = lista;
            lblTotalProductos.Text = $"Total productos: {lista.Count}";
        }

        private void btnAltaProducto_Click(object sender, EventArgs e)
        {
            if (txtNombreProducto.Text == "" || txtPrecioProducto.Text == "") return;

            decimal precio;
            if (!decimal.TryParse(txtPrecioProducto.Text, out precio)) return;

            productosController.Alta(txtNombreProducto.Text, precio);
            CargarProductos();
        }

        private void btnModificarProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;

            int id = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
            decimal precio;
            if (!decimal.TryParse(txtPrecioProducto.Text, out precio)) return;

            productosController.Modificar(id, txtNombreProducto.Text, precio);
            CargarProductos();
        }

        private void btnBajaProducto_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;

            int id = (int)dgvProductos.SelectedRows[0].Cells["Id"].Value;
            string nombre = dgvProductos.SelectedRows[0].Cells["Nombre"].Value.ToString();

            var confirm = MessageBox.Show(
                $"¿Seguro que deseas eliminar el producto \"{nombre}\"?",
                "Confirmar eliminación",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                productosController.Baja(id);
                CargarProductos();
            }
        }

        private void btnRefrescarProducto_Click(object sender, EventArgs e)
        {
            CargarProductos();
        }

        private void btnImportarExcelProductos_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Excel (*.xlsx)|*.xlsx";
                ofd.Title = "Importar productos desde Excel";

                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        var lista = ExcelImporter.ImportProductos(ofd.FileName);

                        foreach (var prod in lista)
                            productosController.Alta(prod.Nombre, prod.Precio);

                        CargarProductos();

                        MessageBox.Show($"Se han importado {lista.Count} productos.", "Importación completada",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al importar productos: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnExportarExcelProductos_Click(object sender, EventArgs e)
        {
            var lista = productosController.Listar();
            if (lista.Count == 0)
            {
                MessageBox.Show("No hay productos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Excel (*.xlsx)|*.xlsx";
                sfd.Title = "Guardar listado de productos";
                sfd.FileName = "productos.xlsx";

                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        ExcelExporter.ExportProductos(sfd.FileName, lista);

                        MessageBox.Show(
                            $"Productos exportados correctamente a:\n{sfd.FileName}",
                            "Exportación completada",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al exportar productos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void txtBuscarProducto_TextChanged(object sender, EventArgs e)
        {
            var texto = txtBuscarProducto.Text.ToLower();
            dgvProductos.DataSource = productosController.Listar()
                .Where(p => p.Nombre.ToLower().Contains(texto)
                         || p.Precio.ToString().Contains(texto))
                .ToList();
        }
        private void btnLimpiarProducto_Click(object sender, EventArgs e)
        {
            txtNombreProducto.Text = "";
            txtPrecioProducto.Text = "";
            txtBuscarProducto.Text = "";
            dgvProductos.ClearSelection();
        }

        private void dgvProductos_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var lista = productosController.Listar();

            string col = dgvProductos.Columns[e.ColumnIndex].DataPropertyName;

            if (dgvProductos.Tag == null || (string)dgvProductos.Tag == "DESC")
            {
                dgvProductos.DataSource = lista.OrderBy(x => x.GetType().GetProperty(col).GetValue(x, null)).ToList();
                dgvProductos.Tag = "ASC";
            }
            else
            {
                dgvProductos.DataSource = lista.OrderByDescending(x => x.GetType().GetProperty(col).GetValue(x, null)).ToList();
                dgvProductos.Tag = "DESC";
            }

            lblTotalProductos.Text = $"Total productos: {lista.Count}";
        }

        private void dgvProductos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0) return;
            txtNombreProducto.Text = dgvProductos.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            txtPrecioProducto.Text = dgvProductos.SelectedRows[0].Cells["Precio"].Value?.ToString();
        }
    }
}