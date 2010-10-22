using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using WindowsFormsASeguimientoIncidentesBD1.show;

namespace WindowsFormsApplication1
{
    public partial class Login_Window : Form
    {
        public Login_Window()
        {
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
            //Buscar usuario y validar contraseña
            //validarUsuario();

            string usuCod = this.textBox1.Text;
            string usuPass = this.textBox2.Text;

            if (DataCurrentUser.validarUsuario(usuCod, usuPass))
            {

                Principal_Window principal = new Principal_Window(this);
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
