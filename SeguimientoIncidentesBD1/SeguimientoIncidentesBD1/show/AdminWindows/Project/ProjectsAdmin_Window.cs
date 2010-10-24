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
            cargarGridProyectos();
        }

        private void cargarGridProyectos()
        {
            DataSet proyectos = new View_Logic().View_GeneralProjects();
            this.dataGridView2.DataSource = proyectos;
            this.dataGridView2.DataMember = "proyecto";
            this.dataGridView2.Columns[0].HeaderText = "Codigo";
            this.dataGridView2.Columns[0].Width = 70;
            this.dataGridView2.Columns[1].HeaderText = "Nombre del Proyecto";
            this.dataGridView2.Columns[1].Width = 300;
            this.dataGridView2.Columns[2].HeaderText = "Estado actual";
            this.dataGridView2.Columns[2].Width = 180;
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
            Int32 projectSelected = Int32.Parse(this.dataGridView2.CurrentRow.Cells[0].Value.ToString());
            this.cache.Proyecto = new Proyecto_Logic(projectSelected);
            ViewProject_Window viewProject = new ViewProject_Window(this, this.cache);
            this.Visible = false;
            viewProject.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewProject_Window newProject = new NewProject_Window(this, this.cache);
            this.Visible = false;
            newProject.Visible = true;
        }

        private void ProjectsAdmin_Window_VisibleChanged(object sender, EventArgs e)
        {
            cargarGridProyectos();
        }
    }
}
