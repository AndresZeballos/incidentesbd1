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
    public partial class ViewUser_Window : Form
    {

        private UserAdmin_Window userAdmin;

        public ViewUser_Window(UserAdmin_Window userAdmin)
        {
            InitializeComponent();
            this.userAdmin = userAdmin;
            this.Location = this.userAdmin.Location;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.button2.Enabled = true;
            this.textBox3.Enabled = true;
            this.textBox4.Enabled = true;
            this.textBox5.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Estas seguro que desa eliminar usuario", "AVISO", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //Eliminar usuario
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ViewUser_FormClosed(object sender, FormClosedEventArgs e)
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
    }
}
