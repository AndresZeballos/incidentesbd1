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
    }
}
