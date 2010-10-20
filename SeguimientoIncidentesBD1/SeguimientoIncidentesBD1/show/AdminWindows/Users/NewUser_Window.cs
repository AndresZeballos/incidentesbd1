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
    public partial class NewUser_Window : Form
    {

        private UserAdmin_Window userAdmin;

        public NewUser_Window(UserAdmin_Window userAdmin)
        {
            InitializeComponent();
            this.userAdmin = userAdmin;
            this.Location = this.userAdmin.Location;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox3.Text.Equals("") || this.textBox4.Text.Equals(""))
            {
                this.button2.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            if (this.textBox4.Text.Equals("") || this.textBox3.Text.Equals(""))
            {
                this.button2.Enabled = false;
            }
            else
            {
                this.button2.Enabled = true;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void NewUser_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.userAdmin.Location = this.Location;
            this.userAdmin.Visible = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            RolUser rolUser = new RolUser(this);
            this.Visible = false;
            rolUser.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
