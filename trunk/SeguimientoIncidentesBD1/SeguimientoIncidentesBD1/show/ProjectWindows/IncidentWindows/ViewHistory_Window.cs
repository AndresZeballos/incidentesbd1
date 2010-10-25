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
    public partial class ViewHistory_Window : Form
    {
        private Cache cache;
        private ViewIncident_Window viewIncident;

        public ViewHistory_Window(ViewIncident_Window viewIncident, Cache cache)
        {
            View_Logic view = new View_Logic();

            InitializeComponent();
            this.cache = cache;
            this.viewIncident = viewIncident;
            this.Location = this.viewIncident.Location;

            this.dataGridView2.DataSource = view.HistoriaIncidente(this.cache.Incidente.IncCod);
            this.dataGridView2.DataMember = "historia";

            this.dataGridView2.Columns[0].HeaderText = "Accion";
            this.dataGridView2.Columns[1].HeaderText = "Fecha";
            this.dataGridView2.Columns[2].HeaderText = "Estado Inicial";
            this.dataGridView2.Columns[3].HeaderText = "Estado Final";
            this.dataGridView2.Columns[4].HeaderText = "Tiempo";
            this.dataGridView2.Columns[5].HeaderText = "Usuario";
            this.dataGridView2.Columns[6].HeaderText = "Codigo";
            this.dataGridView2.Columns[6].Visible = false;

            this.dataGridView2.Columns[0].Width = 100;
            this.dataGridView2.Columns[1].Width = 100;
            this.dataGridView2.Columns[2].Width = 100;
            this.dataGridView2.Columns[3].Width = 100;
            this.dataGridView2.Columns[4].Width = 100;
            this.dataGridView2.Columns[5].Width = 100;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewHistory_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.viewIncident.Location = this.Location;
            this.viewIncident.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int histCod = Int32.Parse(this.dataGridView2.CurrentRow.Cells[6].Value.ToString());
            IncidenteHistoria_Logic historia = new IncidenteHistoria_Logic(histCod);
            this.cache.Historia = historia;

            ViewNote viewNote = new ViewNote(this, this.cache);
            this.Visible = false;
            viewNote.Visible = true;
        }
    }
}
