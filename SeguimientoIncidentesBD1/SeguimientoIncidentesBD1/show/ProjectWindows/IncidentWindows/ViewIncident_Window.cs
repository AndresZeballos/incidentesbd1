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
    public partial class ViewIncident_Window : Form
    {

        private Form projectWindow;
        private Cache cache;

        public ViewIncident_Window(Form projectWindow, Cache cache)
        {
            InitializeComponent();
            this.projectWindow = projectWindow;
            this.Location = this.projectWindow.Location;
            this.cache = cache;

            //Controla que tenga el permiso para visualizar la opción de modificar incidente

            Boolean puedeModificar = DataCurrentUser.ValidarSeguridad("Modificador", this.cache.Usuario);

            if (!puedeModificar)
            {
                this.button2.Visible = false;
            }

            //Controla que tenga el permiso para visualizar la opción de estimar incidente y que el estado del incidente lo permite
            Estado_Logic estado = new Estado_Logic(this.cache.Incidente.IncEstCod);

            if ((!puedeModificar) && (estado.EstEst))
            {
                this.button6.Visible = false;
            }

            this.textBox3.Text = this.cache.Incidente.IncCatCod;
            this.textBox8.Text = this.cache.Incidente.IncEstCod;
            this.textBox5.Text = this.cache.Incidente.IncPriCod;
            this.textBox4.Text = this.cache.Incidente.IncSevCod;
            this.textBox1.Text = this.cache.Incidente.IncRes;
            this.textBox2.Text = this.cache.Incidente.IncDes;
            this.textBox9.Text = this.cache.Incidente.IncUsuAsi;
            this.dateTimePicker1.Value = this.cache.Incidente.IncFecIng;
            this.dateTimePicker2.Value = this.cache.Incidente.IncEstFecIni;
            this.dateTimePicker3.Value = this.cache.Incidente.IncFecFin;
            this.dateTimePicker4.Value = this.cache.Incidente.IncEstFecIni;
            this.textBox10.Text = this.cache.Incidente.IncEstHrs.ToString();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewIncident_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.projectWindow.Location = this.Location;
            this.projectWindow.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeIncident_Window changeIncident = new ChangeIncident_Window(this, this.cache);
            this.Visible = true;
            changeIncident.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddNote_Window addNote = new AddNote_Window(this, this.cache);
            this.Visible = false;
            addNote.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EstimateIncident_Window estimateIncident = new EstimateIncident_Window(this, this.cache);
            this.Visible = false;
            estimateIncident.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewHistory_Window viewHistory = new ViewHistory_Window(this, this.cache);
            this.Visible = false;
            viewHistory.Visible = true;
        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
