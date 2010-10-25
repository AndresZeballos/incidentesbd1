using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.logic;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.show
{
    public partial class ViewRol_Window : Form
    {

        private RolAdmin_Window rolWindow;
        private Cache cache;

        public ViewRol_Window(RolAdmin_Window rolWindow, Cache cache)
        {
            InitializeComponent();
            this.rolWindow = rolWindow;
            this.Location = this.rolWindow.Location;
            this.cache = cache;
            this.textBox1.Text = this.cache.Rol.RolCod;
            this.textBox2.Text = this.cache.Rol.RolDes;
            VerSeguridades();
        }

        public void VerSeguridades()
        {
            DataSet seguridadesRol = new View_Logic().View_RolSecurity(this.cache.Rol.RolCod);
            this.dataGridView3.DataSource = seguridadesRol;
            this.dataGridView3.DataMember = "rolSeguridad";
            this.dataGridView3.Columns[0].HeaderText = "Seguridad";
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox2.Enabled = true;
            this.button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desas eliminar", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar_Rol();
            }
        }

        private void Eliminar_Rol()
        {
            try
            {
                this.cache.Rol.RolDelete();
                this.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Error al eliminar rol " + sqlex.Message);
                //throw sqlex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewRol_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rolWindow.Location = this.Location;
            this.rolWindow.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RolSecurity rolSecurity = new RolSecurity(this, this.cache);
            this.Visible = false;
            rolSecurity.Visible = true;
        }

        //Actualizar
        private void button2_Click(object sender, EventArgs e)
        {
            Rol_Logic rolModificado = new Rol_Logic(this.cache.Rol.RolCod);
            rolModificado.RolDesUpdate(this.textBox2.Text);
            this.Close();
        }

        private void ViewRol_Window_VisibleChanged(object sender, EventArgs e)
        {
            VerSeguridades();
        }

    }
}
