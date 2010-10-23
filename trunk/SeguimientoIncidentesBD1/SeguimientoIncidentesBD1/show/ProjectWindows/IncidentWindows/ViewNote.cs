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
    public partial class ViewNote : Form
    {

        private ViewHistory_Window viewHistory;

        public ViewNote(ViewHistory_Window viewHistory)
        {
            InitializeComponent();
            this.viewHistory = viewHistory;
            this.Location = this.viewHistory.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.viewHistory.Visible = true;
        }
    }
}
