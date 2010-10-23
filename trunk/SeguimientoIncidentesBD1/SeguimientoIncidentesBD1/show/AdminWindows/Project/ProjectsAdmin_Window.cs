using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.show
{
    public partial class ProjectsAdmin_Window : Form
    {
        private Cache cache;
        private Admin_Window adminWindow;

        public ProjectsAdmin_Window(Admin_Window adminWindow, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
            this.adminWindow = adminWindow;
            this.Location = this.adminWindow.Location;
            DataSet grupos = new View_Persist().View_GeneralProjects();
            this.dataGridView2.DataSource = grupos;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ProjectsAdmin_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.adminWindow.Location = this.Location;
            this.adminWindow.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewProject_Window viewProject = new ViewProject_Window(this);
            this.Visible = false;
            viewProject.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewProject_Window newProject = new NewProject_Window(this);
            this.Visible = false;
            newProject.Visible = true;
        }
    }
}
