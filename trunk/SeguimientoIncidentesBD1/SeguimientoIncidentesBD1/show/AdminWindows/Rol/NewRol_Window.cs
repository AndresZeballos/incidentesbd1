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
    public partial class NewRol_Window : Form
    {

        private RolAdmin_Window rolWindow;
        private Cache cache;
        private Boolean creado;

        public NewRol_Window(RolAdmin_Window rolWindow, Cache cache)
        {
            InitializeComponent();
            this.rolWindow = rolWindow;
            this.Location = this.rolWindow.Location;
            this.cache = cache;
            this.cache.Rol = null;
            this.creado = false;
        }

        public void VerSeguridad()
        {
            if (this.cache.Rol != null)
            {
                DataSet seguridadesRol = new View_Logic().View_RolSecurity(this.cache.Rol.RolCod);
                this.dataGridView3.DataSource = seguridadesRol;
                this.dataGridView3.DataMember = "rolSeguridad";
                this.dataGridView3.Columns[0].HeaderText = "Seguridad";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string rolNom = this.textBox1.Text;
            string rolDes = this.textBox2.Text;

            if (rolNom.Equals("") || rolDes.Equals(""))
            {
                MessageBox.Show("Falta ingresar un campo");
            }
            else
            {
                try
                {
                    if (this.cache.Rol == null)
                    {
                        Rol_Logic rol = new Rol_Logic(rolNom, rolDes);
                        rol.RolPersist();
                    }
                    MessageBox.Show("Rol ingresado cone exito");
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("No se puede crear el rol" + sqlex.Message);
                }
            }
            this.Close();
        }

        private void NewRol_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rolWindow.Location = this.Location;
            this.rolWindow.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.cache.Grupo == null)
            {
                Rol_Logic rol = new Rol_Logic(this.textBox1.Text, this.textBox2.Text);
                this.textBox1.Enabled = false;
                this.textBox2.Enabled = false;
                rol.RolPersist();
                this.creado = true;
                this.cache.Rol = rol;
            }

            RolSecurity rolSecurity = new RolSecurity(this, this.cache);
            this.Visible = false;
            rolSecurity.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.textBox2.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
            }
        }

        private void NewRol_Window_VisibleChanged(object sender, EventArgs e)
        {
            VerSeguridad();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.textBox2.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
            }
        }
    }
}
