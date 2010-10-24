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
    public partial class ViewHistory_Window : Form
    {
        private Cache cache;
        private ViewIncident_Window viewIncident;

        public ViewHistory_Window(ViewIncident_Window viewIncident, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
            this.viewIncident = viewIncident;
            this.Location = this.viewIncident.Location;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewHistory_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.viewIncident.Location = this.Location;
            this.viewIncident.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ViewNote viewNote = new ViewNote(this, this.cache);
            this.Visible = false;
            viewNote.Visible = true;
        }
    }
}
