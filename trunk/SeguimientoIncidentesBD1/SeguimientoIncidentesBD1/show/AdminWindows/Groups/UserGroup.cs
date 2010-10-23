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
    public partial class UserGroup : Form
    {

        private Form beforeGroupsWindow;
        private Cache cache;

        public UserGroup(Form beforeGroupsWindow, Cache cache)
        {
            InitializeComponent();
            this.beforeGroupsWindow = beforeGroupsWindow;
            this.Location = this.beforeGroupsWindow.Location;
            this.cache = cache;

            cargarGridUsuarios();

            cargarGridrestoUsuarios();
        }

        private void cargarGridUsuarios()
        {
            this.dataGridView2.DataSource = this.cache.UsuariosGrupo;
            this.dataGridView2.DataMember = "usuarioGrupoUsuario";
            this.dataGridView2.Columns[0].HeaderText = "Usuarios del grupo";
        }

        private void cargarGridrestoUsuarios()
        {
            DataSet restoUsuarios = new View_Logic().View_Option_GroupUser(this.cache.Grupo.GrpUsuCod);
            this.dataGridView3.DataSource = restoUsuarios;
            this.dataGridView3.DataMember = "usuario";
            this.dataGridView3.Columns[0].HeaderText = "Usuarios del Sistema";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserGroup_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.beforeGroupsWindow.Location = this.Location;
            this.beforeGroupsWindow.Visible = true;
        }

        //Agregar
        private void button1_Click(object sender, EventArgs e)
        {
            string userSelected = this.dataGridView3.CurrentRow.Cells[0].Value.ToString();
            GrupoUsuario_Logic nuevoUser = new GrupoUsuario_Logic(this.cache.Grupo.GrpUsuCod);
            nuevoUser.GrpUsuAdd(userSelected);
            this.cache.UsuariosGrupo.Tables[0].Rows.Add(userSelected);
            cargarGridUsuarios();
        }
    }
}
