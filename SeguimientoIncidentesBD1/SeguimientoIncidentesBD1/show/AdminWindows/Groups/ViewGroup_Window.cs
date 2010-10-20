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
    public partial class ViewGroups_Window : Form
    {

        private GroupsAdmin_Window groupAdmin;

        public ViewGroups_Window(GroupsAdmin_Window groupAdmin)
        {
            InitializeComponent();
            this.groupAdmin = groupAdmin;
            this.Location = this.groupAdmin.Location;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Enabled = true;
            this.textBox5.Enabled = true;
            this.button4.Enabled = false;
            this.button2.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desas eliminar", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Eliminar grupo
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            UserGroup userGroup = new UserGroup(this);
            this.Visible = false;
            userGroup.Visible = true;
        }

        private void ViewGrupos_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.groupAdmin.Location = this.Location;
            this.groupAdmin.Visible = true;
        }
    }
}
