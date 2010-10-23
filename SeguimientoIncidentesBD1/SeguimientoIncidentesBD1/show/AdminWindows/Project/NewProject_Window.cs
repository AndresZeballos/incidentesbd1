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

        public NewProject_Window(ProjectsAdmin_Window projectAdmin)
        {
            InitializeComponent();
            this.projectAdmin = projectAdmin;
            this.Location = this.projectAdmin.Location;
            this.comboBox1.Items.Add("Desarrollo");
            this.comboBox1.Items.Add("Produccion");
            this.comboBox1.Items.Add("Obsoleto");
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
            GroupsProject groupsProject = new GroupsProject(this);
            this.Visible = false;
            groupsProject.Visible = true;
        }

        //creo el proyecto
        private void button2_Click(object sender, EventArgs e)
        {
            string proNom = this.textBox1.Text;
            string proDes = this.textBox5.Text;
            string proEst = this.comboBox1.SelectedText;

            if (proNom.Equals("") || proDes.Equals(""))
            {
                MessageBox.Show("Falta ingresar un campo");
            }
            else
            {
                try
                {
                    Proyecto_Logic proyecto = new Proyecto_Logic(proNom, proDes, proEst);
                    proyecto.ProyectoPersist();
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
            if (this.textBox1.Text.Equals(""))
            {
                this.button2.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
            }
        }
    }
}
