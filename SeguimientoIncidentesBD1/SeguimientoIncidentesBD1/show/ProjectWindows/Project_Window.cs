using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.persist;
using SeguimientoIncidentesBD1.logic;

namespace SeguimientoIncidentesBD1.show
{
    public partial class Project_Window : Form
    {

        private Principal_Window principal;
        private Cache cache;

        public Project_Window(Principal_Window principal, Cache cache)
        {
            InitializeComponent();
            this.principal = principal;
            this.cache = cache;
            this.Location = this.principal.Location;


            //Controla que tenga el permiso para visualizar la opción de reportar

            Boolean puedeReportar = DataCurrentUser.ValidarSeguridad("Reportador", cache.Usuario);

            if (!puedeReportar)
            {
                this.button4.Visible = false;
                this.textBox3.Visible = false;
            }

            //Controla que tenga permiso a ver los incidentes?????????????????????????????????????

            Boolean verIncidentes = DataCurrentUser.ValidarSeguridad("Espectador", cache.Usuario);

            if (verIncidentes)
            {
                View_Persist view = new View_Persist();
                //DataSet incidentes = view.View_GeneralIncidents(DataCurrentUser.ProyectoActual());
                //this.dataGridView2.DataSource = incidentes;
            }
            else
            {
                this.button7.Visible = false;
            }

            cargarGridIncidentes();
            
        }

        private void cargarGridIncidentes()
        {
            DataSet incidentes = new View_Logic().View_GeneralIncidents(this.cache.Proyecto.ProCod);
            this.dataGridView2.DataSource = incidentes;
            this.dataGridView2.DataMember = "incidente";
            this.dataGridView2.Columns[0].HeaderText = "Codigo"; //incCod, incRes, incUsuAsi, incEstCod
            this.dataGridView2.Columns[1].HeaderText = "Resumen";
            this.dataGridView2.Columns[2].HeaderText = "Usuario asignado";
            this.dataGridView2.Columns[3].HeaderText = "Estado del incidente";
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

        private void button1_Click(object sender, EventArgs e)
        {
            string incCod = this.textBox1.Text;
            //DataCurrentUser.CargarIncidente(incCod);
            //Incidente_Logic incidente = DataCurrentUser.VerIncidente();
            //if (incidente != null)
            //{

            //}
        }

    }
}
