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
    public partial class RolUser : Form
    {
        private Cache cache;
        private Form beforeUserWindow;

        public RolUser(Form beforeUserWindow, Cache cache)
        {
            InitializeComponent();
            this.beforeUserWindow = beforeUserWindow;
            this.cache = cache;
            this.Location = this.beforeUserWindow.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RolUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeUserWindow.Location = this.Location;
            this.beforeUserWindow.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }
    }
}
