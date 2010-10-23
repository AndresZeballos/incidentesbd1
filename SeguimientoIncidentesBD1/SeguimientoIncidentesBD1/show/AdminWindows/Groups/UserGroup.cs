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
    public partial class UserGroup : Form
    {

        private Form beforeGroupsWindow;

        public UserGroup(Form beforeGroupsWindow)
        {
            InitializeComponent();
            this.beforeGroupsWindow = beforeGroupsWindow;
            this.Location = this.beforeGroupsWindow.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeGroupsWindow.Location = this.Location;
            this.beforeGroupsWindow.Visible = true;
        }
    }
}
