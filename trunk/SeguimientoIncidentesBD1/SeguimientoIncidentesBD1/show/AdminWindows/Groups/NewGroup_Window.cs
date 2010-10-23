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
    public partial class NewGroup_Window : Form
    {

        private GroupsAdmin_Window groupsAdmin;

        public NewGroup_Window(GroupsAdmin_Window groupsAdmin)
        {
            InitializeComponent();
            this.groupsAdmin = groupsAdmin;
            this.Location = this.groupsAdmin.Location;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewGroup_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.groupsAdmin.Location = this.Location;
            this.groupsAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserGroup userGroup = new UserGroup(this);
            this.Visible = false;
            userGroup.Visible = true;
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

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
