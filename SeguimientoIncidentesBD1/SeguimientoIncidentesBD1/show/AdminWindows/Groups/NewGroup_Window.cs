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
    public partial class NewGroup_Window : Form
    {

        private GroupsAdmin_Window groupsAdmin;
        private Cache cache;
        private Boolean creado;

        public NewGroup_Window(GroupsAdmin_Window groupsAdmin, Cache cache)
        {
            InitializeComponent();
            this.groupsAdmin = groupsAdmin;
            this.Location = this.groupsAdmin.Location;
            this.cache = cache;
            this.cache.Grupo = null;
            this.creado = false;
        }
      
        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public void VerUsuarios()
        {
            if (this.cache.Grupo != null)
            {
                DataSet usuariosGrupo = new View_Logic().View_GroupUsers(this.cache.Grupo.GrpUsuCod);
                this.dataGridView2.DataSource = usuariosGrupo;
                this.dataGridView2.DataMember = "usuarioGrupoUsuario";
                this.dataGridView2.Columns[0].HeaderText = "Usuarios";
            }
        }

        private void NewGroup_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.groupsAdmin.Location = this.Location;
            this.groupsAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (this.cache.Grupo == null)
            {
                GrupoUsuario_Logic grupo = new GrupoUsuario_Logic(this.textBox1.Text, this.textBox5.Text);
                this.textBox1.Enabled = false;
                this.textBox5.Enabled = false;
                grupo.GrupoUsuarioCreate();
                this.creado = true;
                this.cache.Grupo = grupo;
            }
            UserGroup userGroup = new UserGroup(this, this.cache);
            this.Visible = false;
            userGroup.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.textBox5.Text.Equals(""))
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string grpCod = this.textBox1.Text;
            string grpDes = this.textBox5.Text;

            if (grpCod.Equals("") || grpDes.Equals(""))
            {
                MessageBox.Show("Falta ingresar un campo");
            }
            else
            {
                try
                {
                    if (!creado)
                    {
                        GrupoUsuario_Logic grupo = new GrupoUsuario_Logic(grpCod, grpDes);
                        grupo.GrupoUsuarioCreate();
                    }
                    MessageBox.Show("Grupo creado con exito");
                }
                catch (SqlException sqlex)
                {
                    MessageBox.Show("Error al crear el grupo: " + sqlex.Message);
                }
            }
            this.Close();
        }

        private void NewGroup_Window_VisibleChanged(object sender, EventArgs e)
        {
            VerUsuarios();
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals("") || this.textBox5.Text.Equals(""))
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
    }
}
