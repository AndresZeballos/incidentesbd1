﻿using System;
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
    public partial class ViewIncident_Window : Form
    {

        private Form projectWindow;

        public ViewIncident_Window(Form projectWindow)
        {
            InitializeComponent();
            this.projectWindow = projectWindow;
            this.Location = this.projectWindow.Location;

            Incidente_Logic incidente = DataCurrentUser.verIncidente();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer2_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewIncident_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.projectWindow.Location = this.Location;
            this.projectWindow.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChangeIncident_Window changeIncident = new ChangeIncident_Window(this);
            this.Visible = true;
            changeIncident.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddNote_Window addNote = new AddNote_Window(this);
            this.Visible = false;
            addNote.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            EstimateIncident_Window estimateIncident = new EstimateIncident_Window(this);
            this.Visible = false;
            estimateIncident.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ViewHistory_Window viewHistory = new ViewHistory_Window(this);
            this.Visible = false;
            viewHistory.Visible = true;
        }
    }
}
