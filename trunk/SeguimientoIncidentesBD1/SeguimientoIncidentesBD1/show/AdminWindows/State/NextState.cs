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
    public partial class NextState : Form
    {

        private Form beforeStateWindow;
        private Cache cache;

        public NextState(Form beforeStateWindow, Cache cache)
        {
            InitializeComponent();
            this.beforeStateWindow = beforeStateWindow;
            this.cache = cache;
            this.Location = this.beforeStateWindow.Location;
            cargarGridSiguientesEstados();
            cargarGridrestoEstados();
        }

        private void cargarGridSiguientesEstados()
        {
            DataSet estadosSiguientes = new View_Logic().View_NextStates(this.cache.Estado.EstCod);
            this.dataGridView3.DataSource = estadosSiguientes;
            this.dataGridView3.DataMember = "estadoSiguiente";
            this.dataGridView3.Columns[0].HeaderText = "Estados siguientes";
        }

        private void cargarGridrestoEstados()
        {
            DataSet restoEstados = new View_Logic().View_Option_NextState(this.cache.Estado.EstCod);
            this.dataGridView1.DataSource = restoEstados;
            this.dataGridView1.DataMember = "estado";
            this.dataGridView1.Columns[0].HeaderText = "Estados del Sistema";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NextState_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeStateWindow.Location = this.Location;
            this.beforeStateWindow.Visible = true;
        }

        //Agregar
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string stateSelected = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Estado_Logic nuevoEstadoSiguiente = new Estado_Logic(this.cache.Estado.EstCod);
                nuevoEstadoSiguiente.EstadoSigAdd(stateSelected);
                //this.cache.UsuariosGrupo.Tables[0].Rows.Add(userSelected);
                cargarGridSiguientesEstados();
                cargarGridrestoEstados();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("No hay estados disponibles");
            }
        }
    }
}
