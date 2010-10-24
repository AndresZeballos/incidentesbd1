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

        public NewRol_Window(RolAdmin_Window rolWindow, Cache cache)
        {
            InitializeComponent();
            this.rolWindow = rolWindow;
            this.Location = this.rolWindow.Location;
            this.cache = cache;
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
                    Rol_Logic rol = new Rol_Logic(rolNom, rolDes);
                    rol.RolPersist();
                    MessageBox.Show("Rol ingresado cone exito");
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("No se puede crear el rol" + sqlex.Message);
                }
            }
        }

        private void NewRol_Window_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
