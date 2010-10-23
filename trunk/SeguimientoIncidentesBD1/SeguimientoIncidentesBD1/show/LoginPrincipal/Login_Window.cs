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
    public partial class Login_Window : Form
    {
        private Cache cache;

        public Login_Window(Cache cache)
        {
            this.cache = cache;
            InitializeComponent();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox2.Text.Equals("") || this.textBox1.Text.Equals(""))
            {
                this.button1.Enabled = false;
            }
            else
            {
                this.button1.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.textBox2.Text.Equals(""))
            {
                this.button1.Enabled = false;
            }
            else
            {
                this.button1.Enabled = true;
            }
        }

        //private Boolean validarUsuario()
        //{
        //    DataSet userCurrent = consult_searchUser();

        //}
        private void button1_Click(object sender, EventArgs e)
        {
            string usuPass = this.textBox2.Text;
            string usuCod = this.textBox1.Text;

            if (DataCurrentUser.ValidarUsuario(usuCod, usuPass))
            //chequeo si la contrasena es correcta
            //if (login.ValidarLogin(usuCod, usuPass))
            {
                cache.Usuario = new Usuario_Logic(usuCod);
                Principal_Window principal = new Principal_Window(this, this.cache);
                this.Visible = false;
                principal.Visible = true;            
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Usuario inválido");
                this.textBox1.Text = "";
                this.textBox2.Text = "";
            }            
        }
    }
}
