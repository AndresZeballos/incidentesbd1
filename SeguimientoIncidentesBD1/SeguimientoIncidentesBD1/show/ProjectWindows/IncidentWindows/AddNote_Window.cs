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
    public partial class AddNote_Window : Form
    {
        private string seguridad = "AgregarNota";
        private Cache cache;
        private ViewIncident_Window viewIncident;

        public AddNote_Window(ViewIncident_Window viewIncident, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
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

        private void button4_Click(object sender, EventArgs e)
        {
            string nota = this.textBox2.Text;
            int tiempoInvertido = decimal.ToInt32(this.numericUpDown1.Value);
            int incCod = this.cache.Incidente.IncCod;
            string usuCod = this.cache.Usuario.UsuCod;
            string estado = this.cache.Incidente.IncEstCod;
            DateTime histFec = DateTime.Today;
            string histAcc = this.seguridad;

            if (nota.Equals(""))
            {
                MessageBox.Show("Falta ingresar una nota");
            }
            else
            {
                try
                {
                    IncidenteHistoria_Logic historia = new IncidenteHistoria_Logic(incCod, estado, estado, histFec, histAcc, usuCod,
                        nota, tiempoInvertido);
                    historia.IncidenteHistoriaCreate();
                    MessageBox.Show("Nota agregada con exito");
                    this.Close();
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al agregar la nota: " + sqlex.Message);
                }
            }
        }
    }
}
