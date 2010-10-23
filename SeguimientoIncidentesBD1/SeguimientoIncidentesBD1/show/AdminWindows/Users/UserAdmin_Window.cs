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
    public partial class UserAdmin_Window : Form
    {
        private Cache cache;
        private Admin_Window adminWindow;

        public UserAdmin_Window(Admin_Window adminWindow, Cache cache)
        {
            InitializeComponent();
            this.cache = cache;
            this.adminWindow = adminWindow;
            this.Location = this.adminWindow.Location;
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            ViewUser_Window viewUser = new ViewUser_Window(this, this.cache);
            this.Visible = false;
            viewUser.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void UserAdmin_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.adminWindow.Location = this.Location;
            this.adminWindow.Visible = true;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            NewUser_Window newUser = new NewUser_Window(this, this.cache);
            this.Visible = false;
            newUser.Visible = true;
        }
    }
}
