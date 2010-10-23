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
    public partial class AddNote_Window : Form
    {

        private ViewIncident_Window viewIncident;

        public AddNote_Window(ViewIncident_Window viewIncident)
        {
            InitializeComponent();
            this.viewIncident = viewIncident;
            this.Location = this.viewIncident.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddNote_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.viewIncident.Location = this.Location;
            this.viewIncident.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox2.Text.Equals(""))
            {
                this.button4.Enabled = false;
            }
            else
            {
                this.button4.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
