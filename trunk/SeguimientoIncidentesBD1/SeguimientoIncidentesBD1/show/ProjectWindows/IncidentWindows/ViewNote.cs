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
        private Cache cache;
        private ViewHistory_Window viewHistory;

        public ViewNote(ViewHistory_Window viewHistory, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
            this.viewHistory = viewHistory;
            this.Location = this.viewHistory.Location;
            this.textBox2.Text = this.cache.Historia.IncHistNota;
            this.textBox1.Text = this.cache.Historia.IncHistTiempo.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewNote_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.viewHistory.Location = this.Location;
            this.viewHistory.Visible = true;
        }
    }
}
