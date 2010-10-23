using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.logic;

namespace SeguimientoIncidentesBD1.show
{
    public partial class Principal_Window : Form
    {
        public const string seguridad = "Administrador";
        private Login_Window loginWindow;
        private Cache cache;

        public Principal_Window(Login_Window loginWindow, Cache cache)
        {
            
            InitializeComponent();

            this.loginWindow = loginWindow;
            this.cache = cache;
            this.Location = this.loginWindow.Location;

            //valido si tiene permiso de acceso a las opciones de administraci'on
            if (!DataCurrentUser.ValidarSeguridad(seguridad, this.cache.Usuario))
            {
                this.button3.Visible = false;
                this.textBox3.Visible = false;
            }

            View_Logic vl = new View_Logic();
            List<string> listaProyectos = vl.consult_projectOfUser(cache.Usuario.UsuCod);
            foreach (string proy in listaProyectos)
            {
                this.comboBox1.Items.Add(proy);
            }


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string seleccion = this.comboBox1.Text;
            string stringProCod = seleccion.Split('-')[0];
            int proCod = Int32.Parse(stringProCod);

            Proyecto_Logic proyecto = new Proyecto_Logic(proCod);
            cache.Proyecto = proyecto;

            Project_Window project = new Project_Window(this, this.cache);
            this.Visible = false;
            project.Visible = true;
        }

        private void Principal_Window_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            User_Window userWindow = new User_Window(this, this.cache);
            this.Visible = false;
            userWindow.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Admin_Window adminWindow = new Admin_Window(this, this.cache);
            this.Visible = false;
            adminWindow.Visible = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Principal_Window_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.loginWindow.Location = this.Location;
            this.loginWindow.Visible = true;
        }
    }
}
