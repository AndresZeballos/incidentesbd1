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
    public partial class Search_Window : Form
    {

        private Project_Window projectWindow;

        public Search_Window(Project_Window projectWindow)
        {
            InitializeComponent();
            this.projectWindow = projectWindow;
            this.Location = this.projectWindow.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Search_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.projectWindow.Location = this.Location;
            this.projectWindow.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewIncident_Window viewIncident = new ViewIncident_Window(this);
            this.Visible = false;
            viewIncident.Visible = true;
        }
    }
}
