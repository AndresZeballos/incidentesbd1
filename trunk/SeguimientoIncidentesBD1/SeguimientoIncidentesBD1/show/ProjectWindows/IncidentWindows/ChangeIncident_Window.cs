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
    public partial class ChangeIncident_Window : Form
    {
        private Cache cache;
        private ViewIncident_Window viewIncident;
        private string seguridad = "Modificador";

        public ChangeIncident_Window(ViewIncident_Window viewIncident, Cache cache)
        {
            InitializeComponent();
            this.viewIncident = viewIncident;
            this.Location = this.viewIncident.Location;
            this.cache = cache;

            CargarValores();
        }

        private void CargarValores()
        {
            Incidente_Logic incidente = this.cache.Incidente;
            View_Logic view = new View_Logic();

            //agrego el estado actual
            this.comboBox3.Items.Add(incidente.IncEstCod);
            //cargo los estados siguientes
            IList<string> estados = view.EstadosSiguientes(incidente.IncEstCod);
            foreach (string estado in estados)
            {
                this.comboBox3.Items.Add(estado);
            }
            //dejo seleccionado el estado actual
            this.comboBox3.SelectedItem = incidente.IncEstCod;

            IList<string> severidades = view.View_GeneralSeverity();
            foreach (string severidad in severidades)
            {
                this.comboBox2.Items.Add(severidad);
            }
            this.comboBox2.SelectedItem = incidente.IncSevCod;

            IList<string> prioridades = view.View_GeneralPriority();
            foreach (string prioridad in prioridades)
            {
                this.comboBox1.Items.Add(prioridad);
            }
            this.comboBox1.SelectedItem = incidente.IncPriCod;

            IList<string> categorias = view.View_GeneralCategory();
            foreach (string categoria in categorias)
            {
                this.comboBox5.Items.Add(categoria);
            }
            this.comboBox5.SelectedItem = incidente.IncCatCod;

            IList<string> usuarios = view.userByProject(this.cache.Proyecto.ProCod);
            foreach (string usuario in usuarios)
            {
                this.comboBox4.Items.Add(usuario);
            }
            this.comboBox4.SelectedItem = incidente.IncUsuAsi;

            this.textBox3.Text = this.cache.Incidente.IncRes;
            this.textBox1.Text = this.cache.Incidente.IncDes;

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

        private void button4_Click(object sender, EventArgs e)
        {
            //ATRIBUTOS PARA EL INCIDENTE
            string nota = this.textBox2.Text;
            int tiempoInvertido = decimal.ToInt32(this.numericUpDown1.Value);

            string incRes = this.textBox3.Text;
            string incDes = this.textBox1.Text;
            string incPri = this.comboBox1.SelectedItem.ToString();
            string incSev = this.comboBox2.SelectedItem.ToString();
            string incCat = this.comboBox5.SelectedItem.ToString();
            string incUsuCod = this.cache.Usuario.UsuCod;

            string incUsuAsi = null;
            if (this.comboBox4.SelectedItem != null)
                incUsuAsi = this.comboBox4.SelectedItem.ToString();

            string incEstado = this.comboBox3.SelectedItem.ToString();

            //ATRIBUTOS PARA LA NOTA
            int incCod = this.cache.Incidente.IncCod;
            string usuCod = this.cache.Usuario.UsuCod;
            DateTime histFec = DateTime.Today;
            string histAcc = this.seguridad;
            string incEstadoAnterior = this.cache.Incidente.IncEstCod;

            if (incRes.Equals("") || incDes.Equals("") || nota.Equals(""))
            {
                MessageBox.Show("Faltan ingresar campos");
            }
            else
            {
                try
                {
                    this.cache.Incidente.IncidenteUpdate(incCat, incSev, incPri, incEstado, incUsuAsi, incDes, incRes);
                    IncidenteHistoria_Logic historia = new IncidenteHistoria_Logic(incCod, incEstadoAnterior, incEstado, histFec, 
                        histAcc, usuCod, nota, tiempoInvertido);
                    historia.IncidenteHistoriaCreate();
                    MessageBox.Show("Incidente actualizado con exito");
                    
                    this.Close();
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al actualizar el incidente: " + sqlex.Message);
                }
            }
        }
    }
}
