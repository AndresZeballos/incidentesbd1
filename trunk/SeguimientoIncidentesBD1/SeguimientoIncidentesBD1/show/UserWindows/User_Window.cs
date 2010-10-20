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
    public partial class User_Window : Form
    {
        private Principal_Window project;

        public User_Window(Principal_Window project)
        {
            InitializeComponent();
            this.project = project;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button4.Visible = false;
            this.textBox1.Enabled = true;
            this.textBox3.Enabled = true;
            this.label3.Visible = true;
            this.textBox2.Visible = true;
            this.button3.Visible = true;
            this.button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.button3.Enabled = false;
            this.textBox2.Enabled = true;
        }

        private void User_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.project.Enabled = true;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
