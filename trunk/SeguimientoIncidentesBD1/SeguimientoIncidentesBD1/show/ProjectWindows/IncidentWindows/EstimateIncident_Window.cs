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
    public partial class EstimateIncident_Window : Form
    {

        private Form beforeIncidentWindow;

        public EstimateIncident_Window(Form beforeIncidentWindow)
        {
            InitializeComponent();
            this.beforeIncidentWindow = beforeIncidentWindow;
            this.Location = this.beforeIncidentWindow.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void EstimateIncident_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeIncidentWindow.Location = this.Location;
            this.beforeIncidentWindow.Visible = true;
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
