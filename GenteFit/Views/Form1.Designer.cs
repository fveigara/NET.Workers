using System.Drawing.Text;
using System.Windows.Forms;

namespace GenteFit
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.tabControlMain = new System.Windows.Forms.TabControl();

            this.tabClientes = new System.Windows.Forms.TabPage();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.tabActividades = new System.Windows.Forms.TabPage();
            this.tabSesiones = new System.Windows.Forms.TabPage();
            this.tabReservas = new System.Windows.Forms.TabPage();

            // ---------- TabControl ----------
            this.tabControlMain.Controls.Add(this.tabClientes);
            this.tabControlMain.Controls.Add(this.tabProductos);
            this.tabControlMain.Controls.Add(this.tabActividades);
            this.tabControlMain.Controls.Add(this.tabSesiones);
            this.tabControlMain.Controls.Add(this.tabReservas);
            this.tabControlMain.Location = new System.Drawing.Point(8, 8);
            this.tabControlMain.Size = new System.Drawing.Size(1000, 620);
            this.tabControlMain.SelectedIndex = 0;

            // =========================
            // Tab: Clientes (left grid + right panel)
            // =========================
            this.dgvClientes = new System.Windows.Forms.DataGridView();
            this.pnlClientes = new System.Windows.Forms.Panel();

            // grid
            this.dgvClientes.Location = new System.Drawing.Point(8, 8);
            this.dgvClientes.Size = new System.Drawing.Size(640, 540);
            this.dgvClientes.ReadOnly = true;
            this.dgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvClientes.MultiSelect = false;
            this.dgvClientes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClientes.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvClientes_ColumnHeaderMouseClick);
            this.dgvClientes.SelectionChanged += new System.EventHandler(this.dgvClientes_SelectionChanged);

            // panel
            this.pnlClientes.Location = new System.Drawing.Point(660, 8);
            this.pnlClientes.Size = new System.Drawing.Size(320, 540);
            this.pnlClientes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // controls in panel
            this.lblBuscarCliente = new System.Windows.Forms.Label();
            this.txtBuscarCliente = new System.Windows.Forms.TextBox();
            this.lblTotalClientsLabel = new System.Windows.Forms.Label();

            this.lblNombreCliente = new System.Windows.Forms.Label();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();

            this.lblApellidosCliente = new System.Windows.Forms.Label();
            this.txtApellidosCliente = new System.Windows.Forms.TextBox();

            this.lblDocumentoCliente = new System.Windows.Forms.Label();
            this.txtDocumentoCliente = new System.Windows.Forms.TextBox();

            this.lblEmailCliente = new System.Windows.Forms.Label();
            this.txtEmailCliente = new System.Windows.Forms.TextBox();

            this.lblTelefonoCliente = new System.Windows.Forms.Label();
            this.txtTelefonoCliente = new System.Windows.Forms.TextBox();

            this.btnAltaCliente = new System.Windows.Forms.Button();
            this.btnModificarCliente = new System.Windows.Forms.Button();
            this.btnBajaCliente = new System.Windows.Forms.Button();
            this.btnLimpiarCliente = new System.Windows.Forms.Button();
            this.btnImportarExcelClientes = new System.Windows.Forms.Button();
            this.btnExportarExcelClientes = new System.Windows.Forms.Button();

            // positions
            this.lblBuscarCliente.Text = "Buscar:";
            this.lblBuscarCliente.Location = new System.Drawing.Point(8, 8);
            this.txtBuscarCliente.Location = new System.Drawing.Point(8, 28);
            this.txtBuscarCliente.Size = new System.Drawing.Size(300, 22);
            this.txtBuscarCliente.TextChanged += new System.EventHandler(this.txtBuscarCliente_TextChanged);

            int y = 60;
            int gap = 30;
            this.lblNombreCliente.Text = "Nombre:";
            this.lblNombreCliente.Location = new System.Drawing.Point(8, y);
            this.txtNombreCliente.Location = new System.Drawing.Point(100, y);
            this.txtNombreCliente.Size = new System.Drawing.Size(200, 22);

            y += gap;
            this.lblApellidosCliente.Text = "Apellidos:";
            this.lblApellidosCliente.Location = new System.Drawing.Point(8, y);
            this.txtApellidosCliente.Location = new System.Drawing.Point(100, y);
            this.txtApellidosCliente.Size = new System.Drawing.Size(200, 22);

            y += gap;
            this.lblDocumentoCliente.Text = "DNI/NIF:";
            this.lblDocumentoCliente.Location = new System.Drawing.Point(8, y);
            this.txtDocumentoCliente.Location = new System.Drawing.Point(100, y);
            this.txtDocumentoCliente.Size = new System.Drawing.Size(200, 22);

            y += gap;
            this.lblEmailCliente.Text = "Email:";
            this.lblEmailCliente.Location = new System.Drawing.Point(8, y);
            this.txtEmailCliente.Location = new System.Drawing.Point(100, y);
            this.txtEmailCliente.Size = new System.Drawing.Size(200, 22);

            y += gap;
            this.lblTelefonoCliente.Text = "Teléfono:";
            this.lblTelefonoCliente.Location = new System.Drawing.Point(8, y);
            this.txtTelefonoCliente.Location = new System.Drawing.Point(100, y);
            this.txtTelefonoCliente.Size = new System.Drawing.Size(200, 22);

            y += gap + 6;
            this.btnAltaCliente.Text = "Alta";
            this.btnAltaCliente.Location = new System.Drawing.Point(8, y);
            this.btnAltaCliente.Size = new System.Drawing.Size(70, 26);
            this.btnAltaCliente.Click += new System.EventHandler(this.btnAltaCliente_Click);

            this.btnModificarCliente.Text = "Modificar";
            this.btnModificarCliente.Location = new System.Drawing.Point(86, y);
            this.btnModificarCliente.Size = new System.Drawing.Size(80, 26);
            this.btnModificarCliente.Click += new System.EventHandler(this.btnModificarCliente_Click);

            this.btnBajaCliente.Text = "Baja";
            this.btnBajaCliente.Location = new System.Drawing.Point(172, y);
            this.btnBajaCliente.Size = new System.Drawing.Size(70, 26);
            this.btnBajaCliente.Click += new System.EventHandler(this.btnBajaCliente_Click);

            this.btnLimpiarCliente.Text = "Limpiar";
            this.btnLimpiarCliente.Location = new System.Drawing.Point(248, y);
            this.btnLimpiarCliente.Size = new System.Drawing.Size(60, 26);
            this.btnLimpiarCliente.Click += new System.EventHandler(this.btnLimpiarCliente_Click);

            y += gap + 6;
            this.btnImportarExcelClientes.Text = "Importar Excel";
            this.btnImportarExcelClientes.Location = new System.Drawing.Point(8, y);
            this.btnImportarExcelClientes.Size = new System.Drawing.Size(140, 26);
            this.btnImportarExcelClientes.Click += new System.EventHandler(this.btnImportarExcelClientes_Click);

            this.btnExportarExcelClientes.Text = "Exportar Excel";
            this.btnExportarExcelClientes.Location = new System.Drawing.Point(154, y);
            this.btnExportarExcelClientes.Size = new System.Drawing.Size(154, 26);
            this.btnExportarExcelClientes.Click += new System.EventHandler(this.btnExportarExcelClientes_Click);

            y += gap + 10;
            this.lblTotalClientsLabel = new System.Windows.Forms.Label();
            this.lblTotalClientsLabel.Location = new System.Drawing.Point(8, y);
            this.lblTotalClientsLabel.Size = new System.Drawing.Size(300, 20);
            this.lblTotalClientsLabel.Text = "Total clientes: 0";

            // add controls to panel
            this.pnlClientes.Controls.Add(this.lblBuscarCliente);
            this.pnlClientes.Controls.Add(this.txtBuscarCliente);
            this.pnlClientes.Controls.Add(this.lblNombreCliente);
            this.pnlClientes.Controls.Add(this.txtNombreCliente);
            this.pnlClientes.Controls.Add(this.lblApellidosCliente);
            this.pnlClientes.Controls.Add(this.txtApellidosCliente);
            this.pnlClientes.Controls.Add(this.lblDocumentoCliente);
            this.pnlClientes.Controls.Add(this.txtDocumentoCliente);
            this.pnlClientes.Controls.Add(this.lblEmailCliente);
            this.pnlClientes.Controls.Add(this.txtEmailCliente);
            this.pnlClientes.Controls.Add(this.lblTelefonoCliente);
            this.pnlClientes.Controls.Add(this.txtTelefonoCliente);
            this.pnlClientes.Controls.Add(this.btnAltaCliente);
            this.pnlClientes.Controls.Add(this.btnModificarCliente);
            this.pnlClientes.Controls.Add(this.btnBajaCliente);
            this.pnlClientes.Controls.Add(this.btnLimpiarCliente);
            this.pnlClientes.Controls.Add(this.btnImportarExcelClientes);
            this.pnlClientes.Controls.Add(this.btnExportarExcelClientes);
            this.pnlClientes.Controls.Add(this.lblTotalClientsLabel);

            // add to tab
            this.tabClientes.Controls.Add(this.dgvClientes);
            this.tabClientes.Controls.Add(this.pnlClientes);

            // =========================
            // Tab: Productos
            // similar layout: left grid, right panel with product fields
            // =========================
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.pnlProductos = new System.Windows.Forms.Panel();

            this.dgvProductos.Location = new System.Drawing.Point(8, 8);
            this.dgvProductos.Size = new System.Drawing.Size(640, 540);
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProductos_ColumnHeaderMouseClick);
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);

            this.pnlProductos.Location = new System.Drawing.Point(660, 8);
            this.pnlProductos.Size = new System.Drawing.Size(320, 540);
            this.pnlProductos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // product controls
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.lblTotalProductsLabel = new System.Windows.Forms.Label();

            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.lblPrecioProducto = new System.Windows.Forms.Label();
            this.txtPrecioProducto = new System.Windows.Forms.TextBox();

            this.btnAltaProducto = new System.Windows.Forms.Button();
            this.btnModificarProducto = new System.Windows.Forms.Button();
            this.btnBajaProducto = new System.Windows.Forms.Button();
            this.btnLimpiarProducto = new System.Windows.Forms.Button();
            this.btnExportarExcelProductos = new System.Windows.Forms.Button();
            this.btnExportarExcelProductos = new System.Windows.Forms.Button();

            // positions
            this.lblBuscarProducto.Text = "Buscar:";
            this.lblBuscarProducto.Location = new System.Drawing.Point(8, 8);
            this.txtBuscarProducto.Location = new System.Drawing.Point(8, 28);
            this.txtBuscarProducto.Size = new System.Drawing.Size(300, 22);
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);

            int py = 60;
            this.lblNombreProducto.Text = "Nombre:";
            this.lblNombreProducto.Location = new System.Drawing.Point(8, py);
            this.txtNombreProducto.Location = new System.Drawing.Point(90, py);
            this.txtNombreProducto.Size = new System.Drawing.Size(210, 22);

            py += gap;
            this.lblPrecioProducto.Text = "Precio:";
            this.lblPrecioProducto.Location = new System.Drawing.Point(8, py);
            this.txtPrecioProducto.Location = new System.Drawing.Point(90, py);
            this.txtPrecioProducto.Size = new System.Drawing.Size(210, 22);

            py += gap + 6;
            this.btnAltaProducto.Text = "Alta";
            this.btnAltaProducto.Location = new System.Drawing.Point(8, py);
            this.btnAltaProducto.Size = new System.Drawing.Size(70, 26);
            this.btnAltaProducto.Click += new System.EventHandler(this.btnAltaProducto_Click);

            this.btnModificarProducto.Text = "Modificar";
            this.btnModificarProducto.Location = new System.Drawing.Point(86, py);
            this.btnModificarProducto.Size = new System.Drawing.Size(80, 26);
            this.btnModificarProducto.Click += new System.EventHandler(this.btnModificarProducto_Click);

            this.btnBajaProducto.Text = "Baja";
            this.btnBajaProducto.Location = new System.Drawing.Point(172, py);
            this.btnBajaProducto.Size = new System.Drawing.Size(70, 26);
            this.btnBajaProducto.Click += new System.EventHandler(this.btnBajaProducto_Click);

            this.btnLimpiarProducto.Text = "Limpiar";
            this.btnLimpiarProducto.Location = new System.Drawing.Point(248, py);
            this.btnLimpiarProducto.Size = new System.Drawing.Size(60, 26);
            this.btnLimpiarProducto.Click += new System.EventHandler(this.btnLimpiarProducto_Click);

            py += gap + 6;
            this.btnImportarExcelProductos = new System.Windows.Forms.Button();
            this.btnImportarExcelProductos = new System.Windows.Forms.Button();

            this.btnImportarExcelProductos.Text = "Importar Excel";
            this.btnImportarExcelProductos.Location = new System.Drawing.Point(8, py);
            this.btnImportarExcelProductos.Size = new System.Drawing.Size(140, 26);
            this.btnImportarExcelProductos.Click += new System.EventHandler(this.btnImportarExcelProductos_Click);

            this.btnExportarExcelProductos.Text = "Exportar Excel";
            this.btnExportarExcelProductos.Location = new System.Drawing.Point(154, py);
            this.btnExportarExcelProductos.Size = new System.Drawing.Size(154, 26);
            this.btnExportarExcelProductos.Click += new System.EventHandler(this.btnExportarExcelProductos_Click);

            py += gap + 6;
            this.lblTotalProductsLabel = new System.Windows.Forms.Label();
            this.lblTotalProductsLabel.Location = new System.Drawing.Point(8, py);
            this.lblTotalProductsLabel.Size = new System.Drawing.Size(300, 20);
            this.lblTotalProductsLabel.Text = "Total productos: 0";

            // add product controls
            this.pnlProductos.Controls.Add(this.lblBuscarProducto);
            this.pnlProductos.Controls.Add(this.txtBuscarProducto);
            this.pnlProductos.Controls.Add(this.lblNombreProducto);
            this.pnlProductos.Controls.Add(this.txtNombreProducto);
            this.pnlProductos.Controls.Add(this.lblPrecioProducto);
            this.pnlProductos.Controls.Add(this.txtPrecioProducto);
            this.pnlProductos.Controls.Add(this.btnAltaProducto);
            this.pnlProductos.Controls.Add(this.btnModificarProducto);
            this.pnlProductos.Controls.Add(this.btnBajaProducto);
            this.pnlProductos.Controls.Add(this.btnLimpiarProducto);
            this.pnlProductos.Controls.Add(this.btnImportarExcelProductos);
            this.pnlProductos.Controls.Add(this.btnExportarExcelProductos);
            this.pnlProductos.Controls.Add(this.lblTotalProductsLabel);

            this.tabProductos.Controls.Add(this.dgvProductos);
            this.tabProductos.Controls.Add(this.pnlProductos);

            // =========================
            // Tab: Actividades (left grid, right panel)
            // =========================
            this.dgvActividades = new System.Windows.Forms.DataGridView();
            this.pnlActividades = new System.Windows.Forms.Panel();

            this.dgvActividades.Location = new System.Drawing.Point(8, 8);
            this.dgvActividades.Size = new System.Drawing.Size(640, 540);
            this.dgvActividades.ReadOnly = true;
            this.dgvActividades.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvActividades.MultiSelect = false;
            this.dgvActividades.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvActividades.SelectionChanged += new System.EventHandler(this.dgvActividades_SelectionChanged);

            this.pnlActividades.Location = new System.Drawing.Point(660, 8);
            this.pnlActividades.Size = new System.Drawing.Size(320, 540);
            this.pnlActividades.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // actividad controls
            this.lblNombreActividad = new System.Windows.Forms.Label();
            this.txtNombreActividad = new System.Windows.Forms.TextBox();
            this.lblDescripcionActividad = new System.Windows.Forms.Label();
            this.txtDescripcionActividad = new System.Windows.Forms.TextBox();
            this.lblIntensidadActividad = new System.Windows.Forms.Label();
            this.cmbIntensidadActividad = new System.Windows.Forms.ComboBox();

            this.btnAltaActividad = new System.Windows.Forms.Button();
            this.btnModificarActividad = new System.Windows.Forms.Button();
            this.btnBajaActividad = new System.Windows.Forms.Button();
            this.btnLimpiarActividad = new System.Windows.Forms.Button();

            // positions
            int ay = 8;
            this.lblNombreActividad.Text = "Nombre:";
            this.lblNombreActividad.Location = new System.Drawing.Point(8, ay);
            this.txtNombreActividad.Location = new System.Drawing.Point(8, ay + 20);
            this.txtNombreActividad.Size = new System.Drawing.Size(300, 22);

            ay += 48;
            this.lblDescripcionActividad.Text = "Descripción:";
            this.lblDescripcionActividad.Location = new System.Drawing.Point(8, ay);
            this.txtDescripcionActividad.Location = new System.Drawing.Point(8, ay + 20);
            this.txtDescripcionActividad.Size = new System.Drawing.Size(300, 80);
            this.txtDescripcionActividad.Multiline = true;

            ay += 110;
            this.lblIntensidadActividad.Text = "Intensidad:";
            this.lblIntensidadActividad.Location = new System.Drawing.Point(8, ay);
            this.cmbIntensidadActividad.Location = new System.Drawing.Point(8, ay + 20);
            this.cmbIntensidadActividad.Size = new System.Drawing.Size(200, 22);
            this.cmbIntensidadActividad.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbIntensidadActividad.Items.AddRange(new object[] { "Baja", "Media", "Alta" });

            ay += 60;
            this.btnAltaActividad.Text = "Alta";
            this.btnAltaActividad.Location = new System.Drawing.Point(8, ay);
            this.btnAltaActividad.Click += new System.EventHandler(this.btnAltaActividad_Click);

            this.btnModificarActividad.Text = "Modificar";
            this.btnModificarActividad.Location = new System.Drawing.Point(86, ay);
            this.btnModificarActividad.Click += new System.EventHandler(this.btnModificarActividad_Click);

            this.btnBajaActividad.Text = "Baja";
            this.btnBajaActividad.Location = new System.Drawing.Point(174, ay);
            this.btnBajaActividad.Click += new System.EventHandler(this.btnBajaActividad_Click);

            this.btnLimpiarActividad.Text = "Limpiar";
            this.btnLimpiarActividad.Location = new System.Drawing.Point(252, ay);
            this.btnLimpiarActividad.Click += new System.EventHandler(this.btnLimpiarActividad_Click);

            this.pnlActividades.Controls.Add(this.lblNombreActividad);
            this.pnlActividades.Controls.Add(this.txtNombreActividad);
            this.pnlActividades.Controls.Add(this.lblDescripcionActividad);
            this.pnlActividades.Controls.Add(this.txtDescripcionActividad);
            this.pnlActividades.Controls.Add(this.lblIntensidadActividad);
            this.pnlActividades.Controls.Add(this.cmbIntensidadActividad);
            this.pnlActividades.Controls.Add(this.btnAltaActividad);
            this.pnlActividades.Controls.Add(this.btnModificarActividad);
            this.pnlActividades.Controls.Add(this.btnBajaActividad);
            this.pnlActividades.Controls.Add(this.btnLimpiarActividad);

            this.tabActividades.Controls.Add(this.dgvActividades);
            this.tabActividades.Controls.Add(this.pnlActividades);

            // =========================
            // Tab: Sesiones
            // =========================
            this.dgvSesiones = new System.Windows.Forms.DataGridView();
            this.pnlSesiones = new System.Windows.Forms.Panel();

            this.dgvSesiones.Location = new System.Drawing.Point(8, 8);
            this.dgvSesiones.Size = new System.Drawing.Size(640, 260);
            this.dgvSesiones.ReadOnly = true;
            this.dgvSesiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvSesiones.MultiSelect = false;
            this.dgvSesiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSesiones.SelectionChanged += new System.EventHandler(this.dgvSesiones_SelectionChanged);

            this.pnlSesiones.Location = new System.Drawing.Point(660, 8);
            this.pnlSesiones.Size = new System.Drawing.Size(320, 540);
            this.pnlSesiones.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // session controls (in panel)
            this.lblActividadSesion = new System.Windows.Forms.Label();
            this.cmbActividadSesion = new System.Windows.Forms.ComboBox();
            this.lblFechaSesion = new System.Windows.Forms.Label();
            this.dtpFechaSesion = new System.Windows.Forms.DateTimePicker();
            this.lblHoraSesion = new System.Windows.Forms.Label();
            this.dtpHoraSesion = new System.Windows.Forms.DateTimePicker();
            this.dtpHoraSesion.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraSesion.ShowUpDown = true;
            this.lblSalaSesion = new System.Windows.Forms.Label();
            this.txtSalaSesion = new System.Windows.Forms.TextBox();
            this.lblMonitorSesion = new System.Windows.Forms.Label();
            this.txtMonitorSesion = new System.Windows.Forms.TextBox();
            this.lblAforoSesion = new System.Windows.Forms.Label();
            this.numAforoSesion = new System.Windows.Forms.NumericUpDown();
            this.numAforoSesion.Minimum = 1;
            this.numAforoSesion.Maximum = 100;
            this.numAforoSesion.Value = 16;

            this.btnAltaSesion = new System.Windows.Forms.Button();
            this.btnModificarSesion = new System.Windows.Forms.Button();
            this.btnBajaSesion = new System.Windows.Forms.Button();
            this.btnLimpiarSesion = new System.Windows.Forms.Button();

            // positions
            int sy = 8;
            this.lblActividadSesion.Text = "Actividad:";
            this.lblActividadSesion.Location = new System.Drawing.Point(8, sy);
            this.cmbActividadSesion.Location = new System.Drawing.Point(8, sy + 20);
            this.cmbActividadSesion.Size = new System.Drawing.Size(300, 22);

            sy += 40;
            this.lblFechaSesion.Text = "Fecha:";
            this.lblFechaSesion.Location = new System.Drawing.Point(8, sy);
            this.dtpFechaSesion.Location = new System.Drawing.Point(8, sy + 20);
            this.dtpFechaSesion.Format = System.Windows.Forms.DateTimePickerFormat.Short;

            sy += 40;
            this.lblHoraSesion.Text = "Hora:";
            this.lblHoraSesion.Location = new System.Drawing.Point(8, sy);
            this.dtpHoraSesion.Location = new System.Drawing.Point(8, sy + 20);
            this.dtpHoraSesion.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtpHoraSesion.ShowUpDown = true;

            sy += 40;
            this.lblSalaSesion.Text = "Sala:";
            this.lblSalaSesion.Location = new System.Drawing.Point(8, sy);
            this.txtSalaSesion.Location = new System.Drawing.Point(8, sy + 20);
            this.txtSalaSesion.Size = new System.Drawing.Size(200, 22);

            sy += 40;
            this.lblMonitorSesion.Text = "Monitor:";
            this.lblMonitorSesion.Location = new System.Drawing.Point(8, sy);
            this.txtMonitorSesion.Location = new System.Drawing.Point(8, sy + 20);
            this.txtMonitorSesion.Size = new System.Drawing.Size(200, 22);

            sy += 40;
            this.lblAforoSesion.Text = "Aforo máx:";
            this.lblAforoSesion.Location = new System.Drawing.Point(8, sy);
            this.numAforoSesion.Location = new System.Drawing.Point(80, sy + 20);
            this.numAforoSesion.Size = new System.Drawing.Size(80, 22);

            sy += 60;
            this.btnAltaSesion.Text = "Crear sesión";
            this.btnAltaSesion.Location = new System.Drawing.Point(8, sy);
            this.btnAltaSesion.Click += new System.EventHandler(this.btnAltaSesion_Click);

            this.btnModificarSesion.Text = "Modificar sesión";
            this.btnModificarSesion.Location = new System.Drawing.Point(112, sy);
            this.btnModificarSesion.Click += new System.EventHandler(this.btnModificarSesion_Click);

            this.btnBajaSesion.Text = "Eliminar sesión";
            this.btnBajaSesion.Location = new System.Drawing.Point(8, sy + 34);
            this.btnBajaSesion.Click += new System.EventHandler(this.btnBajaSesion_Click);

            this.btnLimpiarSesion.Text = "Limpiar";
            this.btnLimpiarSesion.Location = new System.Drawing.Point(112, sy + 34);
            this.btnLimpiarSesion.Click += new System.EventHandler(this.btnLimpiarSesion_Click);

            // add session controls
            this.pnlSesiones.Controls.Add(this.lblActividadSesion);
            this.pnlSesiones.Controls.Add(this.cmbActividadSesion);
            this.pnlSesiones.Controls.Add(this.lblFechaSesion);
            this.pnlSesiones.Controls.Add(this.dtpFechaSesion);
            this.pnlSesiones.Controls.Add(this.lblHoraSesion);
            this.pnlSesiones.Controls.Add(this.dtpHoraSesion);
            this.pnlSesiones.Controls.Add(this.lblSalaSesion);
            this.pnlSesiones.Controls.Add(this.txtSalaSesion);
            this.pnlSesiones.Controls.Add(this.lblMonitorSesion);
            this.pnlSesiones.Controls.Add(this.txtMonitorSesion);
            this.pnlSesiones.Controls.Add(this.lblAforoSesion);
            this.pnlSesiones.Controls.Add(this.numAforoSesion);
            this.pnlSesiones.Controls.Add(this.btnAltaSesion);
            this.pnlSesiones.Controls.Add(this.btnModificarSesion);
            this.pnlSesiones.Controls.Add(this.btnBajaSesion);
            this.pnlSesiones.Controls.Add(this.btnLimpiarSesion);

            this.tabSesiones.Controls.Add(this.dgvSesiones);
            this.tabSesiones.Controls.Add(this.pnlSesiones);

            // =========================
            // Tab: Reservas
            // Left top: sesiones grid, left bottom: confirmed/waiting; Right: reservation actions
            // =========================
            this.dgvReservasSesiones = new System.Windows.Forms.DataGridView();
            this.dgvReservasConfirmed = new System.Windows.Forms.DataGridView();
            this.dgvReservasWaiting = new System.Windows.Forms.DataGridView();
            this.pnlReservas = new System.Windows.Forms.Panel();

            this.dgvReservasSesiones.Location = new System.Drawing.Point(8, 8);
            this.dgvReservasSesiones.Size = new System.Drawing.Size(640, 200);
            this.dgvReservasSesiones.ReadOnly = true;
            this.dgvReservasSesiones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvReservasSesiones.MultiSelect = false;
            this.dgvReservasSesiones.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReservasSesiones.SelectionChanged += new System.EventHandler(this.dgvReservasSesiones_SelectionChanged);

            this.dgvReservasConfirmed.Location = new System.Drawing.Point(8, 220);
            this.dgvReservasConfirmed.Size = new System.Drawing.Size(310, 220);
            this.dgvReservasConfirmed.ReadOnly = true;
            this.dgvReservasConfirmed.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.dgvReservasWaiting.Location = new System.Drawing.Point(338, 220);
            this.dgvReservasWaiting.Size = new System.Drawing.Size(310, 220);
            this.dgvReservasWaiting.ReadOnly = true;
            this.dgvReservasWaiting.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            this.pnlReservas.Location = new System.Drawing.Point(660, 8);
            this.pnlReservas.Size = new System.Drawing.Size(320, 540);
            this.pnlReservas.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

            // reservation actions controls
            this.lblReservasCliente = new System.Windows.Forms.Label();
            this.cmbReservasCliente = new System.Windows.Forms.ComboBox();
            this.lblReservasSesion = new System.Windows.Forms.Label();
            this.txtReservasSesionId = new System.Windows.Forms.TextBox();
            this.btnReservar = new System.Windows.Forms.Button();
            this.btnCancelarReserva = new System.Windows.Forms.Button();

            this.lblReservasCliente.Text = "Cliente:";
            this.lblReservasCliente.Location = new System.Drawing.Point(8, 8);
            this.cmbReservasCliente.Location = new System.Drawing.Point(8, 28);
            this.cmbReservasCliente.Size = new System.Drawing.Size(300, 22);
            this.cmbReservasCliente.DropDownStyle = ComboBoxStyle.DropDownList;

            this.lblReservasSesion.Text = "Sesión (id):";
            this.lblReservasSesion.Location = new System.Drawing.Point(8, 60);
            this.txtReservasSesionId.Location = new System.Drawing.Point(8, 80);
            this.txtReservasSesionId.Size = new System.Drawing.Size(100, 22);
            this.txtReservasSesionId.ReadOnly = true;

            this.btnReservar.Text = "Reservar plaza";
            this.btnReservar.Location = new System.Drawing.Point(8, 120);
            this.btnReservar.Click += new System.EventHandler(this.btnReservar_Click);

            this.btnCancelarReserva.Text = "Cancelar reserva";
            this.btnCancelarReserva.Location = new System.Drawing.Point(120, 120);
            this.btnCancelarReserva.Click += new System.EventHandler(this.btnCancelarReserva_Click);

            this.pnlReservas.Controls.Add(this.lblReservasCliente);
            this.pnlReservas.Controls.Add(this.cmbReservasCliente);
            this.pnlReservas.Controls.Add(this.lblReservasSesion);
            this.pnlReservas.Controls.Add(this.txtReservasSesionId);
            this.pnlReservas.Controls.Add(this.btnReservar);
            this.pnlReservas.Controls.Add(this.btnCancelarReserva);

            this.tabReservas.Controls.Add(this.dgvReservasSesiones);
            this.tabReservas.Controls.Add(this.dgvReservasConfirmed);
            this.tabReservas.Controls.Add(this.dgvReservasWaiting);
            this.tabReservas.Controls.Add(this.pnlReservas);

            // Add tabs to main control already done above
            // Final form settings
            this.ClientSize = new System.Drawing.Size(1024, 640);
            this.Controls.Add(this.tabControlMain);
            this.Text = "GenteFit - Gestión completa";
            this.Load += new System.EventHandler(this.Form1_Load);
        }

        #endregion

        // Controls declaration (public/private)
        private System.Windows.Forms.TabControl tabControlMain;

        private System.Windows.Forms.TabPage tabClientes;
        private System.Windows.Forms.DataGridView dgvClientes;
        private System.Windows.Forms.Panel pnlClientes;
        private System.Windows.Forms.Label lblBuscarCliente;
        private System.Windows.Forms.TextBox txtBuscarCliente;
        private System.Windows.Forms.Label lblNombreCliente;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label lblApellidosCliente;
        private System.Windows.Forms.TextBox txtApellidosCliente;
        private System.Windows.Forms.Label lblDocumentoCliente;
        private System.Windows.Forms.TextBox txtDocumentoCliente;
        private System.Windows.Forms.Label lblEmailCliente;
        private System.Windows.Forms.TextBox txtEmailCliente;
        private System.Windows.Forms.Label lblTelefonoCliente;
        private System.Windows.Forms.TextBox txtTelefonoCliente;
        private System.Windows.Forms.Button btnAltaCliente;
        private System.Windows.Forms.Button btnModificarCliente;
        private System.Windows.Forms.Button btnBajaCliente;
        private System.Windows.Forms.Button btnLimpiarCliente;
        private System.Windows.Forms.Button btnImportarExcelClientes;
        private System.Windows.Forms.Button btnExportarExcelClientes;
        private System.Windows.Forms.Label lblTotalClientsLabel;

        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.Panel pnlProductos;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.Label lblPrecioProducto;
        private System.Windows.Forms.TextBox txtPrecioProducto;
        private System.Windows.Forms.Button btnAltaProducto;
        private System.Windows.Forms.Button btnModificarProducto;
        private System.Windows.Forms.Button btnBajaProducto;
        private System.Windows.Forms.Button btnLimpiarProducto;
        private System.Windows.Forms.Button btnImportarExcelProductos;
        private System.Windows.Forms.Button btnExportarExcelProductos;
        private System.Windows.Forms.Label lblTotalProductsLabel;

        private System.Windows.Forms.TabPage tabActividades;
        private System.Windows.Forms.DataGridView dgvActividades;
        private System.Windows.Forms.Panel pnlActividades;
        private System.Windows.Forms.Label lblNombreActividad;
        private System.Windows.Forms.TextBox txtNombreActividad;
        private System.Windows.Forms.Label lblDescripcionActividad;
        private System.Windows.Forms.TextBox txtDescripcionActividad;
        private System.Windows.Forms.Label lblIntensidadActividad;
        private System.Windows.Forms.ComboBox cmbIntensidadActividad;
        private System.Windows.Forms.Button btnAltaActividad;
        private System.Windows.Forms.Button btnModificarActividad;
        private System.Windows.Forms.Button btnBajaActividad;
        private System.Windows.Forms.Button btnLimpiarActividad;

        private System.Windows.Forms.TabPage tabSesiones;
        private System.Windows.Forms.DataGridView dgvSesiones;
        private System.Windows.Forms.Panel pnlSesiones;
        private System.Windows.Forms.Label lblActividadSesion;
        private System.Windows.Forms.ComboBox cmbActividadSesion;
        private System.Windows.Forms.Label lblFechaSesion;
        private System.Windows.Forms.DateTimePicker dtpFechaSesion;
        private System.Windows.Forms.Label lblHoraSesion;
        private System.Windows.Forms.DateTimePicker dtpHoraSesion;
        private System.Windows.Forms.Label lblSalaSesion;
        private System.Windows.Forms.TextBox txtSalaSesion;
        private System.Windows.Forms.Label lblMonitorSesion;
        private System.Windows.Forms.TextBox txtMonitorSesion;
        private System.Windows.Forms.Label lblAforoSesion;
        private System.Windows.Forms.NumericUpDown numAforoSesion;
        private System.Windows.Forms.Button btnAltaSesion;
        private System.Windows.Forms.Button btnModificarSesion;
        private System.Windows.Forms.Button btnBajaSesion;
        private System.Windows.Forms.Button btnLimpiarSesion;

        private System.Windows.Forms.TabPage tabReservas;
        private System.Windows.Forms.DataGridView dgvReservasSesiones;
        private System.Windows.Forms.DataGridView dgvReservasConfirmed;
        private System.Windows.Forms.DataGridView dgvReservasWaiting;
        private System.Windows.Forms.Panel pnlReservas;
        private System.Windows.Forms.Label lblReservasCliente;
        private System.Windows.Forms.ComboBox cmbReservasCliente;
        private System.Windows.Forms.Label lblReservasSesion;
        private System.Windows.Forms.TextBox txtReservasSesionId;
        private System.Windows.Forms.Button btnReservar;
        private System.Windows.Forms.Button btnCancelarReserva;
    }
}