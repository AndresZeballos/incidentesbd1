﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.persist;
using SeguimientoIncidentesBD1.logic;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.show
{
    public partial class ViewGroup_Window : Form
    {

        private GroupsAdmin_Window groupAdmin;
        private Cache cache;

        public ViewGroup_Window(GroupsAdmin_Window groupAdmin, Cache cache)
        {
            InitializeComponent();
            this.groupAdmin = groupAdmin;
            this.Location = this.groupAdmin.Location;
            this.cache = cache;
            this.textBox1.Text = cache.Grupo.GrpUsuCod;
            this.textBox5.Text = cache.Grupo.GrpUsuDes;
            VerUsuarios();
        }

        public void VerUsuarios()
        {
            DataSet usuariosGrupo = new View_Logic().View_GroupUsers(this.cache.Grupo.GrpUsuCod);
            this.dataGridView1.DataSource = usuariosGrupo;
            this.dataGridView1.DataMember = "usuarioGrupoUsuario";
            this.dataGridView1.Columns[0].HeaderText = "Usuarios";
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //this.textBox1.Enabled = true;
            this.textBox5.Enabled = true;
            this.button4.Enabled = false;
            this.button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desas eliminar", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar_Grupo();
            }
        }

        private void Eliminar_Grupo()
        {
            try
            {
                this.cache.Grupo.GrupoUsuarioDelete();
                this.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Error al eliminar grupo " + sqlex.Message);
                //throw sqlex;
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserGroup userGroup = new UserGroup(this, this.cache);
            this.Visible = false;
            userGroup.Visible = true;
        }

        private void ViewGrupos_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.groupAdmin.Location = this.Location;
            this.groupAdmin.Visible = true;
        }

        private void ViewGroup_Window_VisibleChanged(object sender, EventArgs e)
        {
            this.VerUsuarios();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GrupoUsuario_Logic grupoModificado = new GrupoUsuario_Logic(this.cache.Grupo.GrpUsuCod);
            grupoModificado.GrupoUsuarioDesUpdate(this.textBox5.Text);
            this.Close();
        }
    }
}
