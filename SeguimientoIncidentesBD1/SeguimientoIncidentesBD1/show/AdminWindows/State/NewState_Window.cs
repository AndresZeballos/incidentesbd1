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
        private Boolean creado;

        public NewState_Window(StateAdmin_Window stateAdmin, Cache cache)
        {
            InitializeComponent();
            this.stateAdmin = stateAdmin;
            this.cache = cache;
            this.Location = this.stateAdmin.Location;
            this.creado = false;
            this.cache.Estado = null;
        }

        public void VerSiguientesEstados()
        {
            if (this.cache.Estado != null)
            {
                DataSet estadosSiguientes = new View_Logic().View_NextStates(this.cache.Estado.EstCod);
                this.dataGridView3.DataSource = estadosSiguientes;
                this.dataGridView3.DataMember = "estadoSiguiente";
                this.dataGridView3.Columns[0].HeaderText = "Estados siguientes";
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("")||this.comboBox1.Text.Equals("")||this.comboBox2.Text.Equals("")||
                this.comboBox3.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
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
            if (this.cache.Estado == null)
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

                if (this.comboBox2.SelectedItem.ToString().Equals("Si"))
                {
                    estFin = true;
                }
                else
                {
                    estFin = false;
                }

                if (this.comboBox3.SelectedItem.ToString().Equals("Si"))
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
                Estado_Logic estado = new Estado_Logic(estCod, estIni,estFin,estEst);
                this.textBox1.Enabled = false;
                this.comboBox1.Enabled = false;
                this.comboBox2.Enabled = false;
                this.comboBox3.Enabled = false;
                estado.EstadoPersist();
                this.creado = true;
                this.cache.Estado = estado;
            }

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

            if (this.comboBox2.SelectedItem.ToString().Equals("Si"))
            {
                estFin = true;
            }
            else
            {
                estFin = false;
            }

            if (this.comboBox3.SelectedItem.ToString().Equals("Si"))
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
                    if (!this.creado)
                    {
                        Estado_Logic estado = new Estado_Logic(estCod, estIni, estFin, estEst);
                        estado.EstadoPersist();
                    }
                    MessageBox.Show("Estado creado con exito");
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al crear el estado: " + sqlex.Message);
                }
                this.Close();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.comboBox1.Text.Equals("") || this.comboBox2.Text.Equals("") ||
                 this.comboBox3.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.comboBox1.Text.Equals("") || this.comboBox2.Text.Equals("") ||
                 this.comboBox3.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.comboBox1.Text.Equals("") || this.comboBox2.Text.Equals("") ||
              this.comboBox3.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
            }
        }

        private void NewState_Window_VisibleChanged(object sender, EventArgs e)
        {
            VerSiguientesEstados();
        }
    }
}
