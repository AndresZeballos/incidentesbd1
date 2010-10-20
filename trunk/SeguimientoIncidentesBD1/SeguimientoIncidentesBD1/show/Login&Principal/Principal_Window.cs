using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Principal_Window : Form
    {

        private Login_Window loginWindow;

        public Principal_Window(Login_Window loginWindow)
        {
            
            InitializeComponent();
            
            this.loginWindow = loginWindow;
            this.Location = this.loginWindow.Location;

            //tiene permiso de administrador.
            Boolean esAdministrador = true;
            if (!esAdministrador)
            {
                this.button3.Visible = false;
                this.textBox3.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Project_Window project = new Project_Window(this);
            this.Visible = false;
            project.Visible = true;
        }

        private void Principal_Window_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_Window userWindow = new User_Window(this);
            this.Visible = false;
            userWindow.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Window adminWindow = new Admin_Window(this);
            this.Visible = false;
            adminWindow.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Principal_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.loginWindow.Location = this.Location;
            this.loginWindow.Visible = true;
        }
    }
}
