﻿using System;
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
    public partial class ViewUser_Window : Form
    {
        private Cache cache;
        private UserAdmin_Window userAdmin;

        public ViewUser_Window(UserAdmin_Window userAdmin, Cache cache)
        {
            InitializeComponent();
            this.userAdmin = userAdmin;
            this.cache = cache;
            this.Location = this.userAdmin.Location;
            this.textBox1.Text = this.cache.UsuarioSelected.UsuCod;
            this.textBox3.Text = this.cache.UsuarioSelected.UsuNom;
            this.textBox4.Text = this.cache.UsuarioSelected.UsuPass;
            this.textBox5.Text = this.cache.UsuarioSelected.UsuMail;
            VerRoles();
        }

        public void VerRoles()
        {
            DataSet rolesUsuario = new View_Logic().View_UserRol(this.cache.UsuarioSelected.UsuCod);
            this.dataGridView3.DataSource = rolesUsuario;
            this.dataGridView3.DataMember = "usuarioRol";
            this.dataGridView3.Columns[0].HeaderText = "Roles";

        }

        //Modificar datos
        private void button4_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desa eliminar usuario", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Eliminar_Usuario();
            }
        }

        private void Eliminar_Usuario()
        {
            try
            {
                this.cache.UsuarioSelected.UsuarioDelete();
                this.Close();
            }
            catch (SqlException sqlex)
            {
                MessageBox.Show("Error al eliminar usuario " + sqlex.Message);
                //throw sqlex;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewUser_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.userAdmin.Location = this.Location;
            this.userAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RolUser rolUser = new RolUser(this, this.cache);
            this.Visible = false;
            rolUser.Visible = true;
        }

        //Actualizar
        private void button2_Click(object sender, EventArgs e)
        {
            Usuario_Logic usuarioModificado = new Usuario_Logic(this.cache.UsuarioSelected.UsuCod);
            usuarioModificado.UsuarioUpdate(this.textBox3.Text, this.textBox4.Text, this.textBox5.Text);
            this.Close();
        }

        private void ViewUser_Window_VisibleChanged(object sender, EventArgs e)
        {
            VerRoles();
        }
    }
}
