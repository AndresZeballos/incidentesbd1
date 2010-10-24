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
    public partial class StateAdmin_Window : Form
    {
        private Cache cache;
        private Admin_Window adminWindow;

        public StateAdmin_Window(Admin_Window adminWindow, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
            this.adminWindow = adminWindow;
            this.Location = this.adminWindow.Location;
        }

        private void cargarGridEstados()
        {
            DataSet estados = new View_Logic().Consult_GeneralState();
            this.dataGridView3.DataSource = estados;
            this.dataGridView3.DataMember = "estado";
            this.dataGridView3.Columns[0].HeaderText = "Nombre";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String stateSelected = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
            this.cache.Estado = new Estado_Logic(stateSelected);
            ViewState_Window viewState = new ViewState_Window(this, this.cache);
            this.Visible = false;
            viewState.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewState_Window newState = new NewState_Window(this, this.cache);
            this.Visible = false;
            newState.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StateAdmin_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.adminWindow.Location = this.Location;
            this.adminWindow.Visible = true;
        }

        private void StateAdmin_Window_VisibleChanged(object sender, EventArgs e)
        {
            cargarGridEstados();
        }
    }
}
