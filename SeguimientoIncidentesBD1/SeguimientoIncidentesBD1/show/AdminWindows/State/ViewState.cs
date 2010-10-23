using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Enabled = false;
            this.comboBox4.Enabled = true;
            this.comboBox5.Enabled = true;
            this.comboBox6.Enabled = true;
            this.textBox1.Enabled = true;
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
    }
}
