using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class NewProject_Window : Form
    {

        private ProjectsAdmin_Window projectAdmin;

        public NewProject_Window(ProjectsAdmin_Window projectAdmin)
        {
            InitializeComponent();
            this.projectAdmin = projectAdmin;
            this.Location = this.projectAdmin.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CreateProject_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.projectAdmin.Location = this.Location;
            this.projectAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            GroupsProject groupsProject = new GroupsProject(this);
            this.Visible = false;
            groupsProject.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox1.Text.Equals(""))
            {
                this.button2.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
            }
        }
    }
}
