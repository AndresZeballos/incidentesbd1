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
    public partial class RolSecurity : Form
    {
        private Form beforeRolWindow;

        public RolSecurity(Form beforeRolWindow)
        {
            InitializeComponent();
            this.beforeRolWindow = beforeRolWindow;
            this.Location = this.beforeRolWindow.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RolSecurity_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeRolWindow.Location = this.Location;
            this.beforeRolWindow.Visible = true;
        }

    }
}
