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
    public partial class Report_Window : Form
    {
        private Project_Window project;

        public Report_Window(Project_Window project)
        {
            InitializeComponent();
            this.project = project;
            this.Location = this.project.Location;

            this.button1.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Reporter_Window_Load(object sender, EventArgs e)
        {

        }

        private void Reporter_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.project.Location = this.Location;
            this.project.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(""))
            {
                this.button1.Enabled = false;
            }
            else
            {
                this.button1.Enabled = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            EstimateIncident_Window estimateIncident = new EstimateIncident_Window(this);
            this.Visible = false;
            estimateIncident.Visible = true;
        }
    }
}
