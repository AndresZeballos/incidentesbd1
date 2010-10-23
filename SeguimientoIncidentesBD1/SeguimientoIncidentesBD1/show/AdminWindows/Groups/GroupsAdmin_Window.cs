using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.persist;
using SeguimientoIncidentesBD1.logic;

namespace SeguimientoIncidentesBD1.show
{
    public partial class GroupsAdmin_Window : Form
    {
        private Admin_Window adminWindow;
        private Cache cache;

        public GroupsAdmin_Window(Admin_Window adminWindow, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
            this.adminWindow = adminWindow;
            this.Location = this.adminWindow.Location;
            DataSet grupos = new View_Persist().View_GeneralGroups();
            this.dataGridView2.DataSource = grupos;
            this.dataGridView2.DataMember = "grupoUsuario";
            this.dataGridView2.Columns[0].HeaderText = "Codigo";
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GruposAdmin_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.adminWindow.Location = this.Location;
            this.adminWindow.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String codeSelected = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            this.cache.Grupo = new GrupoUsuario_Logic(codeSelected);
            ViewGroups_Window viewGroups = new ViewGroups_Window(this,this.cache);
            this.Visible = false;
            viewGroups.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewGroup_Window newGroup = new NewGroup_Window(this, this.cache);
            this.Visible = false;
            newGroup.Visible = true;
        }
    }
}
