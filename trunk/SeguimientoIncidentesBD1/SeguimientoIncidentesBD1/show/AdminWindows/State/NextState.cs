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
    }
}
