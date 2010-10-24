using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.logic;

namespace SeguimientoIncidentesBD1.show
{
    public partial class EstimateIncident_Window : Form
    {
        private string seguridad = "EstimarIncidente";
        private Cache cache;
        private Form beforeIncidentWindow;

        public EstimateIncident_Window(Form beforeIncidentWindow, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
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

        private void button4_Click(object sender, EventArgs e)
        {
            int incCod = this.cache.Incidente.IncCod;
            int estHrs = decimal.ToInt32(this.numericUpDown1.Value);
            DateTime fecEstIni = this.dateTimePicker1.Value;
            int dias = estHrs/8;
            System.TimeSpan duration;
            //si el tiempo es menos de un dia, entonces queda para manana
            if (dias == 0)
            {
                duration = new System.TimeSpan(1, 0, 0, 0);
            }
            else
            {
                duration = new System.TimeSpan(dias, 0, 0, 0);
            }
            DateTime fecEstFin = fecEstIni;
            fecEstFin = fecEstFin.Add(duration);

            try
            {
                Incidente_Logic incidente = new Incidente_Logic(incCod);
                incidente.EstimarIncidente(estHrs, fecEstIni, fecEstFin);
                MessageBox.Show("Incidente estimado con exito");
                this.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Error al estimar el incidente: " + sqlex.Message);
            }
        }
    }
}
