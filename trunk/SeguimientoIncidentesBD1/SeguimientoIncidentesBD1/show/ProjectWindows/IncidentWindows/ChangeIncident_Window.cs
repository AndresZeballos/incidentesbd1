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
    public partial class ChangeIncident_Window : Form
    {

        private ViewIncident_Window viewIncident;

        public ChangeIncident_Window(ViewIncident_Window viewIncident)
        {
            InitializeComponent();
            this.viewIncident = viewIncident;
            this.Location = this.viewIncident.Location;
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ChangeIncident_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.viewIncident.Location = this.Location;
            this.viewIncident.Visible = true;
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void ChangeIncident_Window_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
