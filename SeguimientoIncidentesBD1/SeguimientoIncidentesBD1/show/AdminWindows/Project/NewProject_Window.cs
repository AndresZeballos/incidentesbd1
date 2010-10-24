using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.logic;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.show
{
    public partial class NewProject_Window : Form
    {
        
        private ProjectsAdmin_Window projectAdmin;
        private Cache cache;
        private Boolean creado;

        public NewProject_Window(ProjectsAdmin_Window projectAdmin, Cache cache)
        {
            InitializeComponent();
            this.projectAdmin = projectAdmin;
            this.Location = this.projectAdmin.Location;
            this.cache = cache;
            this.cache.Proyecto = null;
            this.creado = false;
        }

        public void VerGrupos()
        {
            if (this.cache.Proyecto != null)
            {
                DataSet gruposProyecto = new View_Logic().View_ProjectGroup(this.cache.Proyecto.ProCod);
                this.dataGridView3.DataSource = gruposProyecto;
                this.dataGridView3.DataMember = "proyectoGrupoUsuario";
                this.dataGridView3.Columns[0].HeaderText = "Grupos del Proyecto";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateProject_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.projectAdmin.Location = this.Location;
            this.projectAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.cache.Proyecto == null)
            {
                Proyecto_Logic proyecto = new Proyecto_Logic(this.textBox1.Text, this.textBox5.Text, this.comboBox1.SelectedItem.ToString());
                this.textBox1.Enabled = false;
                this.textBox5.Enabled = false;
                this.comboBox1.Enabled = false;
                proyecto.ProyectoPersist();
                this.creado = true;
                this.cache.Proyecto = proyecto;
            }
           
            GroupsProject groupsProject = new GroupsProject(this, this.cache);
            this.Visible = false;
            groupsProject.Visible = true;
        }

        //creo el proyecto
        private void button2_Click(object sender, EventArgs e)
        {
            string proNom = this.textBox1.Text;
            string proDes = this.textBox5.Text;
            string proEst = this.comboBox1.SelectedItem.ToString();

            if (proNom.Equals("") || proDes.Equals("")|| proEst.Equals(""))
            {
                MessageBox.Show("Falta ingresar un campo");
            }
            else
            {
                try
                {
                    if (this.cache.Proyecto == null)
                    {
                        Proyecto_Logic proyecto = new Proyecto_Logic(proNom, proDes, proEst);
                        proyecto.ProyectoPersist();
                    }
                    MessageBox.Show("Proyecto creado con exito");
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al crear el proyecto: " + sqlex.Message);
                }
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.textBox5.Text.Equals("") || this.comboBox1.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
            }
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.textBox5.Text.Equals("") || this.comboBox1.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.textBox5.Text.Equals("") || this.comboBox1.Text.Equals(""))
            {
                this.button2.Enabled = false;
                this.button5.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
                this.button5.Enabled = true;
            }
        }

        private void NewProject_Window_VisibleChanged(object sender, EventArgs e)
        {
            VerGrupos();
        }
    }
}
