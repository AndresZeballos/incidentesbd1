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
    public partial class NewUser_Window : Form
    {

        private UserAdmin_Window userAdmin;
        private Cache cache;

        public NewUser_Window(UserAdmin_Window userAdmin, Cache cache)
        {
            InitializeComponent();
            this.userAdmin = userAdmin;
            this.cache = cache;
            this.Location = this.userAdmin.Location;
        }

        //private void textBox3_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.textBox3.Text.Equals("") || this.textBox4.Text.Equals(""))
        //    {
        //        this.button2.Enabled = false;
        //    }
        //    else
        //    {
        //        this.button2.Enabled = true;
        //    }
        //}

        //private void textBox4_TextChanged(object sender, EventArgs e)
        //{
        //    if (this.textBox4.Text.Equals("") || this.textBox3.Text.Equals(""))
        //    {
        //        this.button2.Enabled = false;
        //    }
        //    else
        //    {
        //        this.button2.Enabled = true;
        //    }
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewUser_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.userAdmin.Location = this.Location;
            this.userAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RolUser rolUser = new RolUser(this, this.cache);
            this.Visible = false;
            rolUser.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string usuCod = this.textBox1.Text;
            string usuNom = this.textBox3.Text;
            string usuPass = this.textBox4.Text;
            string usuMail = this.textBox5.Text;

            if (usuCod.Equals("") || usuNom.Equals(""))
            {
                MessageBox.Show("Faltan ingresar campos");
            }
            else
            {
                try
                {
                    Usuario_Logic usuario = new Usuario_Logic(usuCod, usuNom, usuPass, usuMail);
                    usuario.UsuarioPersist();
                    MessageBox.Show("Usuario creado con exito");
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al crear el usuario: " + sqlex.Message);
                }
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
