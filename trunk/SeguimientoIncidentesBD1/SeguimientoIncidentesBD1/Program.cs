using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.persist;
using System.Data;

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
            Conexion cnx = new Conexion();
            ConsultasSelect cs = new ConsultasSelect(cnx);
            DataSet ds = cs.ConsultaGeneral("SELECT * FROM Usuarios");

            DataTable dt = ds.Tables["Usuarios"];
            int i = 0;
            foreach (DataRow drow in dt.Rows)
            {
                Console.WriteLine(drow.Field<string>("nombre"));
                i++;
            }

            //Rol_Persist rol = new Rol_Persist();
            //rol.RolCreate("admin2", "Administrador del Sistema 2", );
        }

        // andres zeballos
    }
}
