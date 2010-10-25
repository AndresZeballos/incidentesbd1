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
    public partial class Parameter : Form
    {

        private Admin_Window adminWindow;
        private String typeParameter;

        public Parameter(Admin_Window adminWindow, String typeParameter)
        {
            InitializeComponent();
            this.adminWindow = adminWindow;
            this.typeParameter = typeParameter;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = true;
            this.textBox2.Enabled = true;
            this.button3.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
