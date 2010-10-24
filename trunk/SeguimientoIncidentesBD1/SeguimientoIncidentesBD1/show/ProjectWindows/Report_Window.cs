using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.logic;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.show
{
    public partial class Report_Window : Form
    {
        private Project_Window project;
        private Cache cache;

        public Report_Window(Project_Window project, Cache cache)
        {
            InitializeComponent();
            this.project = project;
            this.cache = cache;
            this.Location = this.project.Location;
            this.button1.Enabled = false;

            CargarValores();

            this.button6.Visible = false;
        }

        private void CargarValores()
        {
            View_Logic view = new View_Logic();

            IList<string> severidades = view.View_GeneralSeverity();
            foreach (string severidad in severidades)
            {
                this.comboBox2.Items.Add(severidad);
            }

            IList<string> prioridades = view.View_GeneralPriority();
            foreach (string prioridad in prioridades)
            {
                this.comboBox1.Items.Add(prioridad);
            }

            IList<string> categorias = view.View_GeneralCategory();
            foreach (string categoria in categorias)
            {
                this.comboBox3.Items.Add(categoria);
            }

            IList<string> usuarios = view.userByProject(this.cache.Proyecto.ProCod);
            foreach (string usuario in usuarios)
            {
                this.comboBox4.Items.Add(usuario);
            }

            if (DataCurrentUser.ValidarSeguridad("Modificador", cache.Usuario))
                this.comboBox4.Enabled = true;
            else
                this.comboBox4.Enabled = false;
            
            
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
            // OBTENER TODOS LOS VALORES
            string incRes = this.textBox1.Text;
            string incDes = this.textBox2.Text;
            string incPri = this.comboBox1.SelectedItem.ToString();
            string incSev = this.comboBox2.SelectedItem.ToString();
            string incCat = this.comboBox3.SelectedItem.ToString();
            string incUsuCod = this.cache.Usuario.UsuCod;
            string incUsuAsig = null;
            if (this.comboBox4.SelectedItem != null)
                 incUsuAsig = this.comboBox4.SelectedItem.ToString();
            int incProCod = this.cache.Proyecto.ProCod;
            string incEstCodIni = this.cache.EstadoInicial.EstCod;

            try
            {
                Incidente_Logic incidente = new Incidente_Logic(incProCod, incCat, incSev, incPri, incEstCodIni, DateTime.Today,
                    DateTime.Today, incUsuCod, incUsuAsig, incDes, incRes);
                incidente.IncidenteCreate();
                MessageBox.Show("Incidente creado con exito");
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Error al crear el incidente: " + sqlex.Message);
            }

        }

        private void button6_Click(object sender, EventArgs e)
        {
            EstimateIncident_Window estimateIncident = new EstimateIncident_Window(this);
            this.Visible = false;
            estimateIncident.Visible = true;
        }
    }
}
