﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeguimientoIncidentesBD1.show
{
    public partial class Admin_Window : Form
    {
        private Cache cache;
        private Principal_Window principal;

        public Admin_Window(Principal_Window principal, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
            this.principal = principal;
            this.Location = this.principal.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RolAdmin_Window rolAdmin = new RolAdmin_Window(this, this.cache);
            this.Visible = false;
            rolAdmin.Visible = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Admin_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.principal.Location = this.Location;
            this.principal.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UserAdmin_Window userAdmin = new UserAdmin_Window(this, this.cache);
            this.Visible = false;
            userAdmin.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GroupsAdmin_Window groupsAdmin = new GroupsAdmin_Window(this, this.cache);
            this.Visible = false;
            groupsAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ProjectsAdmin_Window projectAdmin = new ProjectsAdmin_Window(this, this.cache);
            this.Visible = false;
            projectAdmin.Visible = true;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            StateAdmin_Window stateAdmin = new StateAdmin_Window(this, this.cache);
            this.Visible = false;
            stateAdmin.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Parameter parameterWindow = new Parameter(this, "seguridad");
            this.Visible = false;
            parameterWindow.Visible = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Parameter parameterWindow = new Parameter(this, "prioridad");
            this.Visible = false;
            parameterWindow.Visible = true;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Parameter parameterWindow = new Parameter(this, "categoria");
            this.Visible = false;
            parameterWindow.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Parameter parameterWindow = new Parameter(this, "severidad");
            this.Visible = false;
            parameterWindow.Visible = true;
        }
    }
}
