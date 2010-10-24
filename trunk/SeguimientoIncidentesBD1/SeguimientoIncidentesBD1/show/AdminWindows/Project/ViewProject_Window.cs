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
    public partial class ViewProject_Window : Form
    {

        private ProjectsAdmin_Window projectAdmin;
        private Cache cache;

        public ViewProject_Window(ProjectsAdmin_Window projectAdmin, Cache cache)
        {
            InitializeComponent();
            this.projectAdmin = projectAdmin;
            this.Location = this.projectAdmin.Location;
            this.cache = cache;
            this.textBox1.Text = this.cache.Proyecto.ProNom;;
            this.textBox5.Text = this.cache.Proyecto.ProDes;
            this.comboBox1.Text = this.cache.Proyecto.ProEst;
            VerGrupos();
        }

        public void VerGrupos()
        {
            DataSet usuariosGrupo = new View_Logic().View_ProjectGroup(this.cache.Proyecto.ProCod);
            this.dataGridView3.DataSource = usuariosGrupo;
            this.dataGridView3.DataMember = "proyectoGrupoUsuario";
            this.dataGridView3.Columns[0].HeaderText = "Grupos";
            this.dataGridView3.Columns[0].Width = 200;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.projectAdmin.Location = this.Location;
            this.projectAdmin.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Enabled = false;
            //this.textBox1.Enabled = true;
            this.textBox5.Enabled = true;
            this.comboBox1.Enabled = true;
            this.button2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GroupsProject groupsProject = new GroupsProject(this, this.cache);
            this.Visible = false;
            groupsProject.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Proyecto_Logic proyectoModificado = new Proyecto_Logic(this.cache.Proyecto.ProCod);
            proyectoModificado.ProyectoUpdate(this.textBox1.Text, this.textBox5.Text, this.comboBox1.Text);
            this.Close();
        }

        private void ViewProject_Window_VisibleChanged(object sender, EventArgs e)
        {
            VerGrupos();
        }
    }
}
