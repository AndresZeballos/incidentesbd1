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
    public partial class ViewState_Window : Form
    {
        private Cache cache;
        private StateAdmin_Window stateAdmin;

        public ViewState_Window(StateAdmin_Window stateAdmin, Cache cache)
        {
            InitializeComponent();
            this.stateAdmin = stateAdmin;
            this.Location = this.stateAdmin.Location;
            this.cache = cache;
            VerSiguientesEstados();
            this.textBox1.Text = this.cache.Estado.EstCod;
            
            if (this.cache.Estado.EstIni)
                this.comboBox6.Text = "Si";
            else
                this.comboBox6.Text = "No";
            if (this.cache.Estado.EstFin)
                this.comboBox5.Text = "Si";
            else
                this.comboBox5.Text = "No";
            if (this.cache.Estado.EstEst)
                this.comboBox4.Text = "Si";
            else
                this.comboBox4.Text = "No";

        }

        public void VerSiguientesEstados()
        {
            DataSet estadosSiguientes = new View_Logic().View_NextStates(this.cache.Estado.EstCod);
            this.dataGridView3.DataSource = estadosSiguientes;
            this.dataGridView3.DataMember = "estadoSiguiente";
            this.dataGridView3.Columns[0].HeaderText = "Estados siguientes";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desas eliminar", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Eliminar estado
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NextState nextState = new NextState(this, this.cache);
            this.Visible = false;
            nextState.Visible = true;
        }

        private void ViewState_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.stateAdmin.Location = this.Location;
            this.stateAdmin.Visible = true;
        }

        private void ViewState_Window_VisibleChanged(object sender, EventArgs e)
        {
            VerSiguientesEstados();
        }
    }
}
