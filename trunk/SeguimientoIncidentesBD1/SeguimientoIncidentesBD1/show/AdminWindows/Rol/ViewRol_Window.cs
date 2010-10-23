using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeguimientoIncidentesBD1.show
{
    public partial class ViewRol_Window : Form
    {

        private RolAdmin_Window rolWindow;

        public ViewRol_Window(RolAdmin_Window rolWindow)
        {
            InitializeComponent();
            this.rolWindow = rolWindow;
            this.Location = this.rolWindow.Location;
        }
        
        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desas eliminar", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Eliminar rol
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
            RolSecurity rolSecurity = new RolSecurity(this);
            this.Visible = false;
            rolSecurity.Visible = true;
        }

    }
}
