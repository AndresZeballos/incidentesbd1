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
    public partial class RolAdmin_Window : Form
    {

        private Admin_Window admin;

        public RolAdmin_Window(Admin_Window admin)
        {
            InitializeComponent();
            this.admin = admin;
            this.Location = this.admin.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewRol_Window newRol = new NewRol_Window(this);
            this.Visible = false;
            newRol.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewRol_Window viewRol = new ViewRol_Window(this);
            this.Visible = false;
            viewRol.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RolAdmin_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.admin.Location = this.Location;
            this.admin.Visible = true;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
