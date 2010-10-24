using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.logic;

namespace SeguimientoIncidentesBD1.show
{
    public partial class RolSecurity : Form
    {
        private Form beforeRolWindow;
        private Cache cache;

        public RolSecurity(Form beforeRolWindow, Cache cache)
        {
            InitializeComponent();
            this.beforeRolWindow = beforeRolWindow;
            this.Location = this.beforeRolWindow.Location;
            this.cache = cache;
        }

        private void cargarGridSeguridades()
        {
            DataSet SeguridadesRol = new View_Logic().View_RolSecurity(this.cache.Rol.RolCod);
            this.dataGridView3.DataSource = SeguridadesRol;
            this.dataGridView3.DataMember = "rolSeguridad";
            this.dataGridView3.Columns[0].HeaderText = "Seguridades del Rol";
            
        }

        private void cargarGridrestoSeguridades()
        {
            DataSet restoSeguridades = new View_Logic().View_Option_RolSecurity(this.cache.Rol.RolCod);
            this.dataGridView1.DataSource = restoSeguridades;
            this.dataGridView1.DataMember = "seguridad";
            this.dataGridView1.Columns[0].HeaderText = "Seguridades del Sistema";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

    }
}
