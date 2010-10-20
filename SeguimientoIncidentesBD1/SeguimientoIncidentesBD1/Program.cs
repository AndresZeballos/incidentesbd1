using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Data;
using SeguimientoIncidentesBD1.logic;
using SeguimientoIncidentesBD1.persist;
using WindowsFormsApplication1;

namespace SeguimientoIncidentesBD1
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Login_Window());
            ////Conexion cnx = new Conexion();
            ////ConsultasSelect cs = new ConsultasSelect(cnx);
            ////DataSet ds = cs.ConsultaGeneral("SELECT * FROM Usuarios");

            ////DataTable dt = ds.Tables["Usuarios"];
            ////int i = 0;
            ////foreach (DataRow drow in dt.Rows)
            ////{
            ////    Console.WriteLine(drow.Field<string>("nombre"));
            ////    i++;
            ////}
            //Seguridad_Persist seg = new Seguridad_Persist("hola", "seguridad hola");
            //seg.SeguridadCreate();
            //Seguridad_Persist seg2 = new Seguridad_Persist("chau", "seguridad chau");
            //seg2.SeguridadCreate();

            //IList<string> rolseg = new List<string>();
            //rolseg.Add("hola");
            //rolseg.Add("chau");

            //Rol_Persist rol = new Rol_Persist("rolPrueba", "rol de prueba", rolseg);
            //rol.RolCreate();

            ////Rol_Persist rol = new Rol_Persist();
            ////rol.RolCreate("admin2", "Administrador del Sistema 2", );
        }

        
    }
}
