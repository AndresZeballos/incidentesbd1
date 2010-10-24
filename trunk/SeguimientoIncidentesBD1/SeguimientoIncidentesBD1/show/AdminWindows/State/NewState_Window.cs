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
    public partial class NewState_Window : Form
    {

        private StateAdmin_Window stateAdmin;
        private Cache cache;

        public NewState_Window(StateAdmin_Window stateAdmin, Cache cache)
        {
            InitializeComponent();
            this.stateAdmin = stateAdmin;
            this.cache = cache;
            this.Location = this.stateAdmin.Location;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(""))
            {
                this.button2.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewState_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.stateAdmin.Location = this.Location;
            this.stateAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            NextState nextState = new NextState(this, this.cache);
            this.Visible = false;
            nextState.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string estCod = this.textBox1.Text;
            bool estIni;
            bool estFin;
            bool estEst;

            if (this.comboBox1.SelectedItem.ToString().Equals("Si"))
            {
                estIni = true;
            }
            else
            {
                estIni = false;
            }

            if (this.comboBox1.SelectedItem.ToString().Equals("Si"))
            {
                estFin = true;
            }
            else
            {
                estFin = false;
            }

            if (this.comboBox1.SelectedItem.ToString().Equals("Si"))
            {
                estEst = true;
            }
            else
            {
                estEst = false;
            }

            if (estCod.Equals(""))
            {
                MessageBox.Show("Falta ingresar un campo");
            }
            else
            {
                try
                {
                    Estado_Logic estado = new Estado_Logic(estCod, estIni, estFin, estEst);
                    estado.EstadoPersist();
                    MessageBox.Show("Estado creado con exito");
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al crear el estado: " + sqlex.Message);
                }
            }
        }
    }
}
