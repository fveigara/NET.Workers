using GenteFit.Data;
using GenteFit.Models;
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
        private GenteFitContext db = new GenteFitContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            CargarSocios();
        }

        private void CargarSocios()
        {
            dgvSocios.DataSource = db.Socios.ToList();
        }

        private void btnAlta_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtEmail.Text))
                return;

            var socio = new Socio
            {
                Nombre = txtNombre.Text,
                Email = txtEmail.Text,
                FechaAlta = DateTime.Now
            };
            db.Socios.Add(socio);
            db.SaveChanges();
            CargarSocios();
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 0) return;
            var id = (int)dgvSocios.SelectedRows[0].Cells["Id"].Value;
            var socio = db.Socios.Find(id);
            if (socio == null) return;

            socio.Nombre = txtNombre.Text;
            socio.Email = txtEmail.Text;
            db.SaveChanges();
            CargarSocios();
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 0) return;
            var id = (int)dgvSocios.SelectedRows[0].Cells["Id"].Value;
            var socio = db.Socios.Find(id);
            if (socio == null) return;

            db.Socios.Remove(socio);
            db.SaveChanges();
            CargarSocios();
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            CargarSocios();
        }

        private void btnImportar_Click(object sender, EventArgs e)
        {
            XmlHandler.ImportarSociosDesdeXml("Xml/socios.xml");
            CargarSocios();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            XmlHandler.ExportarSociosAXml("Xml/socios_salida.xml");
        }

        private void dgvSocios_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvSocios.SelectedRows.Count == 0) return;
            txtNombre.Text = dgvSocios.SelectedRows[0].Cells["Nombre"].Value?.ToString();
            txtEmail.Text = dgvSocios.SelectedRows[0].Cells["Email"].Value?.ToString();
        }
    }
}
