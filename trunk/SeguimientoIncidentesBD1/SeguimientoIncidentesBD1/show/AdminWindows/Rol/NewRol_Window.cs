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
    public partial class NewRol_Window : Form
    {

        private RolAdmin_Window rolWindow;

        public NewRol_Window(RolAdmin_Window rolWindow)
        {
            InitializeComponent();
            this.rolWindow = rolWindow;
            this.Location = this.rolWindow.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro de crear rol", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Eliminar rol
            }
        }

        private void NewRol_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.rolWindow.Location = this.Location;
            this.rolWindow.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RolSecurity rolSecurity = new RolSecurity(this);
            this.Visible = false;
            rolSecurity.Visible = true;
        }
    }
}
