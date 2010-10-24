using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.logic;

namespace SeguimientoIncidentesBD1.show
{
    public partial class Search_Window : Form
    {
        private Cache cache;

        private Project_Window projectWindow;

        public Search_Window(Project_Window projectWindow, Cache cache)
        {
            InitializeComponent();

            this.cache = cache;

            this.projectWindow = projectWindow;
            this.Location = this.projectWindow.Location;

            CarcarOpciones();
        }

        private void CarcarOpciones()
        {
            View_Logic view = new View_Logic();

            IList<string> severidades = view.View_GeneralSeverity();
            foreach (string severidad in severidades)
            {
                this.comboBox8.Items.Add(severidad);
            }

            IList<string> prioridades = view.View_GeneralPriority();
            foreach (string prioridad in prioridades)
            {
                this.comboBox9.Items.Add(prioridad);
            }

            IList<string> categorias = view.View_GeneralCategory();
            foreach (string categoria in categorias)
            {
                this.comboBox7.Items.Add(categoria);
            }

            IList<string> usuarios = view.userByProject(this.cache.Proyecto.ProCod);
            foreach (string usuario in usuarios)
            {
                this.comboBox4.Items.Add(usuario);
            }

            IList<string> estados = view.View_GeneralState();
            foreach (string estado in estados)
            {
                this.comboBox1.Items.Add(estado);
            }
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
            ViewIncident_Window viewIncident = new ViewIncident_Window(this, cache);
            this.Visible = false;
            viewIncident.Visible = true;
        }

        // INICIA LA BUSQUEDA AVANZADA
        private void button1_Click(object sender, EventArgs e)
        {
            string estado = this.comboBox1.Text;
            string usuario = this.comboBox4.Text;
            string categoria = this.comboBox7.Text;
            string severidad = this.comboBox8.Text;
            string prioridad = this.comboBox9.Text;

        }
    }
}
