using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.show;

namespace SeguimientoIncidentesBD1.show
{
    public partial class User_Window : Form
    {
        private Principal_Window project;
        private Cache cache;

        public User_Window(Principal_Window project, Cache cache)
        {
            InitializeComponent();
            this.project = project;
            this.Location = this.project.Location;
            this.cache = cache;
            this.textBox1.Text = cache.Usuario.UsuNom;
            this.textBox3.Text = cache.Usuario.UsuMail;
        }

        // Modificar datos
        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Visible = false;
            this.textBox1.Enabled = true;
            this.textBox3.Enabled = true;
            this.label3.Visible = true;
            this.textBox2.Visible = true;
            this.textBox2.Enabled = false;
            //this.label3.Visible = false;
            this.button3.Visible = true;
            this.button3.Enabled = true;
            this.button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button3.Enabled = false;
            this.textBox2.Enabled = true;
        }

        private void User_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.project.Location = this.Location;
            this.project.Visible = true;
        }

        //CERRAR LA VENTANA
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ACTUALIZAR
        private void button2_Click(object sender, EventArgs e)
        {
            //si el usuario selecciono para cambiar la contrase;a, la actualizo
            if (this.textBox2.Enabled)
            {
                if (this.textBox2.Equals(""))
                {
                    System.Windows.Forms.MessageBox.Show("Ingrese la nueva contrasena");
                }
                else
                {
                    cache.Usuario.UsuarioUpdate(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);

                    System.Windows.Forms.MessageBox.Show("Datos actualizados correctamente");
                    this.Close();
                }
            }
            else
            {
                cache.Usuario.UsuarioUpdate(this.textBox1.Text, this.textBox2.Text, cache.Usuario.UsuPass);
                System.Windows.Forms.MessageBox.Show("Datos actualizados correctamente");
                this.Close();
            }            
        }
    }
}
