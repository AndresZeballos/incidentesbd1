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
    public partial class RolUser : Form
    {
        private Cache cache;
        private Form beforeUserWindow;

        public RolUser(Form beforeUserWindow, Cache cache)
        {
            InitializeComponent();
            this.beforeUserWindow = beforeUserWindow;
            this.cache = cache;
            this.Location = this.beforeUserWindow.Location;
            cargarGridRoles();
            cargarGridrestoRoles();
        }

        private void cargarGridRoles()
        {
            DataSet rolesUsuario = new View_Logic().View_UserRol(this.cache.UsuarioSelected.UsuCod);
            this.dataGridView3.DataSource = rolesUsuario;
            this.dataGridView3.DataMember = "usuarioRol";
            this.dataGridView3.Columns[0].HeaderText = "Roles del Usuario";
        }

        private void cargarGridrestoRoles()
        {
            DataSet restoRoles = new View_Logic().View_Option_UserRol(this.cache.UsuarioSelected.UsuCod);
            this.dataGridView1.DataSource = restoRoles;
            this.dataGridView1.DataMember = "rol";
            this.dataGridView1.Columns[0].HeaderText = "Roles del Sistema";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void RolUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeUserWindow.Location = this.Location;
            this.beforeUserWindow.Visible = true;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string rolSelected = this.dataGridView1.CurrentRow.Cells[0].Value.ToString();
                Usuario_Logic nuevoRol = new Usuario_Logic(this.cache.UsuarioSelected.UsuCod);
                nuevoRol.UsuarioRolAdd(rolSelected);
                //this.cache.UsuariosGrupo.Tables[0].Rows.Add(userSelected);
                cargarGridRoles();
                cargarGridrestoRoles();
            }
            catch (Exception exp)
            {
                System.Windows.Forms.MessageBox.Show("No hay roles disponibles");
            }
        }
    }
}
