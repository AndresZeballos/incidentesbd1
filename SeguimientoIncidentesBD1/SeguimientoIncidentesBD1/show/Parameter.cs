using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.show;
using SeguimientoIncidentesBD1.logic;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1
{
    public partial class Parameter : Form
    {

        private Admin_Window adminWindow;
        private String typeParameter;

        public Parameter(Admin_Window adminWindow, String typeParameter)
        {
            InitializeComponent();
            this.adminWindow = adminWindow;
            this.typeParameter = typeParameter;
            CargarParametro();
        }

        private void CargarParametro()
        {
            DataSet parametro = new View_Logic().View_Parameter(this.typeParameter);
            this.dataGridView2.DataSource = parametro;
            this.dataGridView2.DataMember = this.typeParameter;
            this.dataGridView2.Columns[0].HeaderText = this.typeParameter.ToUpperInvariant();
            if (this.typeParameter.Equals("seguridad"))
            {
                this.dataGridView2.Columns[1].HeaderText = "DESCRIPCION";
                this.dataGridView2.Columns[1].Width = 500;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if(this.typeParameter.Equals("seguridad"))
                this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.button3.Visible = true;
            this.button4.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Parameter_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.adminWindow.Location = this.Location;
            this.adminWindow.Visible = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox2.Text.Equals(""))
            {
                this.button3.Enabled = false;
            }
            else
            {
                this.button3.Enabled = true;
            }
        }

        //Crear nuevo parametro
        private void button3_Click(object sender, EventArgs e)
        {
            Crear_Parameter();
        }

        private void Crear_Parameter()
        {
            string nombre = "";
            if (!this.textBox2.Text.Equals(""))
            {
                nombre = this.textBox2.Text;

                try
                {
                    switch (this.typeParameter)
                    {
                        case "seguridad":
                            Seguridad_Logic nuevaSeguridad = new Seguridad_Logic(nombre, this.textBox1.Text);
                            nuevaSeguridad.SeguridadPersist();
                            break;
                        case "prioridad":
                            Prioridad_Logic nuevaPrioridad = new Prioridad_Logic(nombre);
                            nuevaPrioridad.PrioridadPersist();
                            break;
                        case "categoria":
                            Categoria_Logic nuevaCategoria = new Categoria_Logic(nombre);
                            nuevaCategoria.CategoriaPersist();
                            break;
                        case "severidad":
                            Severidad_Logic nuevaSeveridad = new Severidad_Logic(nombre);
                            nuevaSeveridad.SeveridadPersist();
                            break;
                    }

                    this.button3.Visible = false;
                    this.button4.Visible = true;
                    this.textBox1.Text = "";
                    this.textBox2.Text = "";
                    this.textBox1.Enabled = false;
                    this.textBox2.Enabled = false;

                    CargarParametro();
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al crear parametro" + sqlex.Message);
                    //throw sqlex;
                }
            }
            else
            {
                MessageBox.Show("Falta el nombre del parametro");
            }
        }

        //Eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que deseas eliminar?", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar_Parameter();
            }
            
        }

        private void Eliminar_Parameter()
        {
            string nombre = this.dataGridView2.CurrentRow.Cells[0].Value.ToString();
            if (!nombre.Equals(""))
            {
                try
                {
                    switch (this.typeParameter)
                    {
                        case "seguridad":
                            Seguridad_Logic nuevaSeguridad = new Seguridad_Logic(nombre);
                            nuevaSeguridad.SeguridadDelete(nombre);
                            break;
                        case "prioridad":
                            Prioridad_Logic nuevaPrioridad = new Prioridad_Logic(nombre);
                            nuevaPrioridad.PrioridadDelete();
                            break;
                        case "categoria":
                            Categoria_Logic nuevaCategoria = new Categoria_Logic(nombre);
                            nuevaCategoria.CategoriaDelete();
                            break;
                        case "severidad":
                            Severidad_Logic nuevaSeveridad = new Severidad_Logic(nombre);
                            nuevaSeveridad.SeveridadDelete();
                            break;
                    }

                    CargarParametro();
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al eliminar parámetro" + sqlex.Message);
                    //throw sqlex;
                }
            }
            else
            {
                MessageBox.Show("No hay parametros");
            }
        }
    }
}
