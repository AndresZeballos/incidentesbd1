using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SeguimientoIncidentesBD1.show
{
    public partial class ViewProject_Window : Form
    {

        private ProjectsAdmin_Window projectAdmin;

        public ViewProject_Window(ProjectsAdmin_Window projectAdmin)
        {
            InitializeComponent();
            this.projectAdmin = projectAdmin;
            this.Location = this.projectAdmin.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewProject_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.projectAdmin.Location = this.Location;
            this.projectAdmin.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Enabled = false;
            this.textBox1.Enabled = true;
            this.textBox5.Enabled = true;
            this.comboBox1.Enabled = true;
            this.button2.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GroupsProject groupsProject = new GroupsProject(this);
            this.Visible = false;
            groupsProject.Visible = true;
        }
    }
}
