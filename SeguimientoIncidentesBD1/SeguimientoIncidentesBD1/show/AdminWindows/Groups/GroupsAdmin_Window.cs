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
    public partial class GroupsAdmin_Window : Form
    {

        private Admin_Window adminWindow;

        public GroupsAdmin_Window(Admin_Window adminWindow)
        {
            InitializeComponent();
            this.adminWindow = adminWindow;
            this.Location = this.adminWindow.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void GruposAdmin_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.adminWindow.Location = this.Location;
            this.adminWindow.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ViewGroups_Window viewGroups = new ViewGroups_Window(this);
            this.Visible = false;
            viewGroups.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            NewGroup_Window newGroup = new NewGroup_Window(this);
            this.Visible = false;
            newGroup.Visible = true;
        }
    }
}
