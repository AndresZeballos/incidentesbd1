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
    public partial class GroupsProject : Form
    {

        private Form beforeProjectWindow;

        public GroupsProject(Form beforeProjectWindow)
        {
            InitializeComponent();
            this.beforeProjectWindow = beforeProjectWindow;
            this.Location = this.beforeProjectWindow.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupsProyect_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeProjectWindow.Location = this.Location;
            this.beforeProjectWindow.Visible = true;
        }
    }
}
