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
    public partial class GroupsProject : Form
    {

        private Form beforeProjectWindow;
        private Cache cache;

        public GroupsProject(Form beforeProjectWindow, Cache cache)
        {
            InitializeComponent();
            this.beforeProjectWindow = beforeProjectWindow;
            this.Location = this.beforeProjectWindow.Location;
            this.cache = cache;
            cargarGridGrupos();
            cargarGridrestoGrupos();
        }

        private void cargarGridGrupos()
        {
            DataSet gruposProyecto = new View_Logic().View_ProjectGroup(this.cache.Proyecto.ProCod);
            this.dataGridView2.DataSource = gruposProyecto;
            this.dataGridView2.DataMember = "proyectoGrupoUsuario";
            this.dataGridView2.Columns[0].HeaderText = "Grupos del Proyecto";
        }

        private void cargarGridrestoGrupos()
        {
            DataSet restoGrupos = new View_Logic().View_Option_ProjectGroup(this.cache.Proyecto.ProCod);
            this.dataGridView4.DataSource = restoGrupos;
            this.dataGridView4.DataMember = "grupoUsuario";
            this.dataGridView4.Columns[0].HeaderText = "Grupos del Sistema";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GroupsProyect_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeProjectWindow.Location = this.Location;
            this.beforeProjectWindow.Visible = true;
        }

        //Agregar
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string grupoSelected = this.dataGridView4.CurrentRow.Cells[0].Value.ToString();
                Proyecto_Logic nuevoGrupo = new Proyecto_Logic(this.cache.Proyecto.ProCod);
                nuevoGrupo.ProGrpAdd(grupoSelected);
                //this.cache.UsuariosGrupo.Tables[0].Rows.Add(userSelected);
                cargarGridGrupos();
                cargarGridrestoGrupos();
            }
            catch (Exception exc)
            {
                System.Windows.Forms.MessageBox.Show("No hay grupos disponibles");
            }
        }
    }
}
