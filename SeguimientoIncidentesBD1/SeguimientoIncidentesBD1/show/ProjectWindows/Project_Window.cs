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
    public partial class Project_Window : Form
    {

        private Principal_Window principal;

        public Project_Window(Principal_Window principal)
        {
            InitializeComponent();
            this.principal = principal;
            this.Location = this.principal.Location;


            //Controla que tenga el permiso para visualizar la opción de reportar

            Boolean puedeReportar = true;

            if (!puedeReportar)
            {
                this.button4.Visible = false;
                this.textBox3.Visible = false;
            }




            //Controla que tenga permiso a ver los incidentes?????????????????????????????????????
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Report_Window reporter = new Report_Window(this);
            this.Visible = false;
            reporter.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            ViewIncident_Window viewIncident = new ViewIncident_Window(this);
            this.Visible = false;
            viewIncident.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Search_Window searchWindow = new Search_Window(this);
            this.Visible = false;
            searchWindow.Visible = true;
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Project_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.principal.Location = this.Location;
            this.principal.Visible = true;
        }

    }
}
