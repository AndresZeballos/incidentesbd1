using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.logic;

namespace SeguimientoIncidentesBD1.show
{
    public partial class RolAdmin_Window : Form
    {
        private Cache cache;
        private Admin_Window admin;

        public RolAdmin_Window(Admin_Window admin, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
            this.admin = admin;
            this.Location = this.admin.Location;
            cargarGridRoles();
        }

        private void cargarGridRoles()
        {
            DataSet grupos = new View_Logic().View_GeneralRol();
            this.dataGridView3.DataSource = grupos;
            this.dataGridView3.DataMember = "rol";
            this.dataGridView3.Columns[0].HeaderText = "Nombre";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewRol_Window newRol = new NewRol_Window(this, this.cache);
            this.Visible = false;
            newRol.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String rolSelected = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
            this.cache.Rol = new Rol_Logic(rolSelected);
            ViewRol_Window viewRol = new ViewRol_Window(this, this.cache);
            this.Visible = false;
            viewRol.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RolAdmin_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.admin.Location = this.Location;
            this.admin.Visible = true;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void RolAdmin_Window_VisibleChanged(object sender, EventArgs e)
        {
            cargarGridRoles();
        }
    }
}
