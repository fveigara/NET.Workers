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

        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabSocios = new System.Windows.Forms.TabPage();
            this.dgvSocios = new System.Windows.Forms.DataGridView();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnImportar = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.lblBuscarSocio = new System.Windows.Forms.Label();
            this.txtBuscarSocio = new System.Windows.Forms.TextBox();
            this.lblTotalSocios = new System.Windows.Forms.Label();
            this.btnLimpiarSocio = new System.Windows.Forms.Button();
            this.tabProductos = new System.Windows.Forms.TabPage();
            this.dgvProductos = new System.Windows.Forms.DataGridView();
            this.txtNombreProducto = new System.Windows.Forms.TextBox();
            this.txtPrecioProducto = new System.Windows.Forms.TextBox();
            this.lblNombreProducto = new System.Windows.Forms.Label();
            this.lblPrecioProducto = new System.Windows.Forms.Label();
            this.btnAltaProducto = new System.Windows.Forms.Button();
            this.btnModificarProducto = new System.Windows.Forms.Button();
            this.btnBajaProducto = new System.Windows.Forms.Button();
            this.btnRefrescarProducto = new System.Windows.Forms.Button();
            this.btnImportarProducto = new System.Windows.Forms.Button();
            this.btnExportarProducto = new System.Windows.Forms.Button();
            this.lblBuscarProducto = new System.Windows.Forms.Label();
            this.txtBuscarProducto = new System.Windows.Forms.TextBox();
            this.lblTotalProductos = new System.Windows.Forms.Label();
            this.btnLimpiarProducto = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabSocios.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).BeginInit();
            this.tabProductos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabSocios);
            this.tabControl1.Controls.Add(this.tabProductos);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(584, 330);
            this.tabControl1.TabIndex = 0;
            // 
            // tabSocios
            // 
            this.tabSocios.Controls.Add(this.dgvSocios);
            this.tabSocios.Controls.Add(this.txtNombre);
            this.tabSocios.Controls.Add(this.txtEmail);
            this.tabSocios.Controls.Add(this.lblNombre);
            this.tabSocios.Controls.Add(this.lblEmail);
            this.tabSocios.Controls.Add(this.btnAlta);
            this.tabSocios.Controls.Add(this.btnModificar);
            this.tabSocios.Controls.Add(this.btnBaja);
            this.tabSocios.Controls.Add(this.btnRefrescar);
            this.tabSocios.Controls.Add(this.btnImportar);
            this.tabSocios.Controls.Add(this.btnExportar);
            this.tabSocios.Controls.Add(this.lblBuscarSocio);
            this.tabSocios.Controls.Add(this.txtBuscarSocio);
            this.tabSocios.Controls.Add(this.lblTotalSocios);
            this.tabSocios.Controls.Add(this.btnLimpiarSocio);
            this.tabSocios.Location = new System.Drawing.Point(4, 22);
            this.tabSocios.Name = "tabSocios";
            this.tabSocios.Size = new System.Drawing.Size(576, 304);
            this.tabSocios.TabIndex = 0;
            this.tabSocios.Text = "Socios";
            this.tabSocios.UseVisualStyleBackColor = true;
            // 
            // dgvSocios
            // 
            this.dgvSocios.AllowUserToAddRows = false;
            this.dgvSocios.AllowUserToDeleteRows = false;
            this.dgvSocios.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvSocios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocios.Location = new System.Drawing.Point(3, 3);
            this.dgvSocios.MultiSelect = false;
            this.dgvSocios.Name = "dgvSocios";
            this.dgvSocios.ReadOnly = true;
            this.dgvSocios.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSocios.Size = new System.Drawing.Size(570, 199);
            this.dgvSocios.TabIndex = 0;
            this.dgvSocios.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvSocios_ColumnHeaderMouseClick);
            this.dgvSocios.SelectionChanged += new System.EventHandler(this.dgvSocios_SelectionChanged);
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(53, 232);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(277, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(53, 258);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(277, 20);
            this.txtEmail.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(0, 234);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 3;
            this.lblNombre.Text = "Nombre:";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(0, 261);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(35, 13);
            this.lblEmail.TabIndex = 4;
            this.lblEmail.Text = "Email:";
            // 
            // btnAlta
            // 
            this.btnAlta.Location = new System.Drawing.Point(336, 229);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(75, 23);
            this.btnAlta.TabIndex = 5;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.Location = new System.Drawing.Point(417, 229);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(75, 23);
            this.btnModificar.TabIndex = 6;
            this.btnModificar.Text = "Modificar";
            this.btnModificar.UseVisualStyleBackColor = true;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(494, 229);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(75, 23);
            this.btnBaja.TabIndex = 7;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Location = new System.Drawing.Point(336, 203);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(233, 23);
            this.btnRefrescar.TabIndex = 8;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnImportar
            // 
            this.btnImportar.Location = new System.Drawing.Point(336, 255);
            this.btnImportar.Name = "btnImportar";
            this.btnImportar.Size = new System.Drawing.Size(75, 23);
            this.btnImportar.TabIndex = 9;
            this.btnImportar.Text = "Importar";
            this.btnImportar.UseVisualStyleBackColor = true;
            this.btnImportar.Click += new System.EventHandler(this.btnImportarExcelSocios_Click);
            // 
            // btnExportar
            // 
            this.btnExportar.Location = new System.Drawing.Point(417, 256);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(75, 23);
            this.btnExportar.TabIndex = 10;
            this.btnExportar.Text = "Exportar";
            this.btnExportar.UseVisualStyleBackColor = true;
            this.btnExportar.Click += new System.EventHandler(this.btnExportarExcelProductos_Click);
            // 
            // lblBuscarSocio
            // 
            this.lblBuscarSocio.Location = new System.Drawing.Point(0, 208);
            this.lblBuscarSocio.Name = "lblBuscarSocio";
            this.lblBuscarSocio.Size = new System.Drawing.Size(47, 17);
            this.lblBuscarSocio.TabIndex = 11;
            this.lblBuscarSocio.Text = "Buscar:";
            // 
            // txtBuscarSocio
            // 
            this.txtBuscarSocio.Location = new System.Drawing.Point(53, 205);
            this.txtBuscarSocio.Name = "txtBuscarSocio";
            this.txtBuscarSocio.Size = new System.Drawing.Size(277, 20);
            this.txtBuscarSocio.TabIndex = 12;
            this.txtBuscarSocio.TextChanged += new System.EventHandler(this.txtBuscarSocio_TextChanged);
            // 
            // lblTotalSocios
            // 
            this.lblTotalSocios.Location = new System.Drawing.Point(0, 284);
            this.lblTotalSocios.Name = "lblTotalSocios";
            this.lblTotalSocios.Size = new System.Drawing.Size(576, 20);
            this.lblTotalSocios.TabIndex = 13;
            this.lblTotalSocios.Text = "Total socios: 0";
            // 
            // btnLimpiarSocio
            // 
            this.btnLimpiarSocio.Location = new System.Drawing.Point(494, 255);
            this.btnLimpiarSocio.Name = "btnLimpiarSocio";
            this.btnLimpiarSocio.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarSocio.TabIndex = 14;
            this.btnLimpiarSocio.Text = "Limpiar";
            this.btnLimpiarSocio.Click += new System.EventHandler(this.btnLimpiarSocio_Click);
            // 
            // tabProductos
            // 
            this.tabProductos.Controls.Add(this.dgvProductos);
            this.tabProductos.Controls.Add(this.txtNombreProducto);
            this.tabProductos.Controls.Add(this.txtPrecioProducto);
            this.tabProductos.Controls.Add(this.lblNombreProducto);
            this.tabProductos.Controls.Add(this.lblPrecioProducto);
            this.tabProductos.Controls.Add(this.btnAltaProducto);
            this.tabProductos.Controls.Add(this.btnModificarProducto);
            this.tabProductos.Controls.Add(this.btnBajaProducto);
            this.tabProductos.Controls.Add(this.btnRefrescarProducto);
            this.tabProductos.Controls.Add(this.btnImportarProducto);
            this.tabProductos.Controls.Add(this.btnExportarProducto);
            this.tabProductos.Controls.Add(this.lblBuscarProducto);
            this.tabProductos.Controls.Add(this.txtBuscarProducto);
            this.tabProductos.Controls.Add(this.lblTotalProductos);
            this.tabProductos.Controls.Add(this.btnLimpiarProducto);
            this.tabProductos.Location = new System.Drawing.Point(4, 22);
            this.tabProductos.Name = "tabProductos";
            this.tabProductos.Size = new System.Drawing.Size(576, 304);
            this.tabProductos.TabIndex = 1;
            this.tabProductos.Text = "Productos";
            this.tabProductos.UseVisualStyleBackColor = true;
            // 
            // dgvProductos
            // 
            this.dgvProductos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvProductos.Location = new System.Drawing.Point(3, 3);
            this.dgvProductos.MultiSelect = false;
            this.dgvProductos.Name = "dgvProductos";
            this.dgvProductos.ReadOnly = true;
            this.dgvProductos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvProductos.Size = new System.Drawing.Size(570, 199);
            this.dgvProductos.TabIndex = 0;
            this.dgvProductos.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvProductos_ColumnHeaderMouseClick);
            this.dgvProductos.SelectionChanged += new System.EventHandler(this.dgvProductos_SelectionChanged);
            // 
            // txtNombreProducto
            // 
            this.txtNombreProducto.Location = new System.Drawing.Point(53, 231);
            this.txtNombreProducto.Name = "txtNombreProducto";
            this.txtNombreProducto.Size = new System.Drawing.Size(277, 20);
            this.txtNombreProducto.TabIndex = 1;
            // 
            // txtPrecioProducto
            // 
            this.txtPrecioProducto.Location = new System.Drawing.Point(53, 257);
            this.txtPrecioProducto.Name = "txtPrecioProducto";
            this.txtPrecioProducto.Size = new System.Drawing.Size(277, 20);
            this.txtPrecioProducto.TabIndex = 2;
            // 
            // lblNombreProducto
            // 
            this.lblNombreProducto.Location = new System.Drawing.Point(0, 234);
            this.lblNombreProducto.Name = "lblNombreProducto";
            this.lblNombreProducto.Size = new System.Drawing.Size(73, 14);
            this.lblNombreProducto.TabIndex = 3;
            this.lblNombreProducto.Text = "Nombre:";
            // 
            // lblPrecioProducto
            // 
            this.lblPrecioProducto.Location = new System.Drawing.Point(0, 260);
            this.lblPrecioProducto.Name = "lblPrecioProducto";
            this.lblPrecioProducto.Size = new System.Drawing.Size(66, 14);
            this.lblPrecioProducto.TabIndex = 4;
            this.lblPrecioProducto.Text = "Precio:";
            // 
            // btnAltaProducto
            // 
            this.btnAltaProducto.Location = new System.Drawing.Point(336, 229);
            this.btnAltaProducto.Name = "btnAltaProducto";
            this.btnAltaProducto.Size = new System.Drawing.Size(75, 23);
            this.btnAltaProducto.TabIndex = 5;
            this.btnAltaProducto.Text = "Alta";
            this.btnAltaProducto.Click += new System.EventHandler(this.btnAltaProducto_Click);
            // 
            // btnModificarProducto
            // 
            this.btnModificarProducto.Location = new System.Drawing.Point(417, 229);
            this.btnModificarProducto.Name = "btnModificarProducto";
            this.btnModificarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnModificarProducto.TabIndex = 6;
            this.btnModificarProducto.Text = "Modificar";
            this.btnModificarProducto.Click += new System.EventHandler(this.btnModificarProducto_Click);
            // 
            // btnBajaProducto
            // 
            this.btnBajaProducto.Location = new System.Drawing.Point(494, 229);
            this.btnBajaProducto.Name = "btnBajaProducto";
            this.btnBajaProducto.Size = new System.Drawing.Size(75, 23);
            this.btnBajaProducto.TabIndex = 7;
            this.btnBajaProducto.Text = "Baja";
            this.btnBajaProducto.Click += new System.EventHandler(this.btnBajaProducto_Click);
            // 
            // btnRefrescarProducto
            // 
            this.btnRefrescarProducto.Location = new System.Drawing.Point(336, 203);
            this.btnRefrescarProducto.Name = "btnRefrescarProducto";
            this.btnRefrescarProducto.Size = new System.Drawing.Size(233, 23);
            this.btnRefrescarProducto.TabIndex = 8;
            this.btnRefrescarProducto.Text = "Refrescar";
            this.btnRefrescarProducto.Click += new System.EventHandler(this.btnRefrescarProducto_Click);
            // 
            // btnImportarProducto
            // 
            this.btnImportarProducto.Location = new System.Drawing.Point(336, 255);
            this.btnImportarProducto.Name = "btnImportarProducto";
            this.btnImportarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnImportarProducto.TabIndex = 9;
            this.btnImportarProducto.Text = "Importar";
            this.btnImportarProducto.UseVisualStyleBackColor = true;
            // 
            // btnExportarProducto
            // 
            this.btnExportarProducto.Location = new System.Drawing.Point(417, 255);
            this.btnExportarProducto.Name = "btnExportarProducto";
            this.btnExportarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnExportarProducto.TabIndex = 10;
            this.btnExportarProducto.Text = "Exportar";
            // 
            // lblBuscarProducto
            // 
            this.lblBuscarProducto.Location = new System.Drawing.Point(0, 208);
            this.lblBuscarProducto.Name = "lblBuscarProducto";
            this.lblBuscarProducto.Size = new System.Drawing.Size(47, 15);
            this.lblBuscarProducto.TabIndex = 11;
            this.lblBuscarProducto.Text = "Buscar:";
            // 
            // txtBuscarProducto
            // 
            this.txtBuscarProducto.Location = new System.Drawing.Point(53, 205);
            this.txtBuscarProducto.Name = "txtBuscarProducto";
            this.txtBuscarProducto.Size = new System.Drawing.Size(277, 20);
            this.txtBuscarProducto.TabIndex = 12;
            this.txtBuscarProducto.TextChanged += new System.EventHandler(this.txtBuscarProducto_TextChanged);
            // 
            // lblTotalProductos
            // 
            this.lblTotalProductos.Location = new System.Drawing.Point(0, 283);
            this.lblTotalProductos.Name = "lblTotalProductos";
            this.lblTotalProductos.Size = new System.Drawing.Size(300, 20);
            this.lblTotalProductos.TabIndex = 11;
            this.lblTotalProductos.Text = "Total productos: 0";
            // 
            // btnLimpiarProducto
            // 
            this.btnLimpiarProducto.Location = new System.Drawing.Point(494, 255);
            this.btnLimpiarProducto.Name = "btnLimpiarProducto";
            this.btnLimpiarProducto.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiarProducto.TabIndex = 12;
            this.btnLimpiarProducto.Text = "Limpiar";
            this.btnLimpiarProducto.Click += new System.EventHandler(this.btnLimpiarProducto_Click);
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(609, 350);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Gestión de GenteFit";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.tabControl1.ResumeLayout(false);
            this.tabSocios.ResumeLayout(false);
            this.tabSocios.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocios)).EndInit();
            this.tabProductos.ResumeLayout(false);
            this.tabProductos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvProductos)).EndInit();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.TabPage tabSocios;
        private System.Windows.Forms.DataGridView dgvSocios;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnModificar;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnImportar;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox txtBuscarSocio;
        private System.Windows.Forms.Label lblBuscarSocio;
        private System.Windows.Forms.Label lblTotalSocios;
        private System.Windows.Forms.Button btnLimpiarSocio;

        private System.Windows.Forms.TabPage tabProductos;
        private System.Windows.Forms.DataGridView dgvProductos;
        private System.Windows.Forms.TextBox txtNombreProducto;
        private System.Windows.Forms.TextBox txtPrecioProducto;
        private System.Windows.Forms.Label lblNombreProducto;
        private System.Windows.Forms.Label lblPrecioProducto;
        private System.Windows.Forms.Button btnAltaProducto;
        private System.Windows.Forms.Button btnModificarProducto;
        private System.Windows.Forms.Button btnBajaProducto;
        private System.Windows.Forms.Button btnRefrescarProducto;
        private System.Windows.Forms.Button btnImportarProducto;
        private System.Windows.Forms.Button btnExportarProducto;
        private System.Windows.Forms.TextBox txtBuscarProducto;
        private System.Windows.Forms.Label lblBuscarProducto;
        private System.Windows.Forms.Label lblTotalProductos;
        private System.Windows.Forms.Button btnLimpiarProducto;

    }
}