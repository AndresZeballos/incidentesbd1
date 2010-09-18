using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SeguimientoIncidentesBD1.persist;

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
            Rol rol = new Rol();
            rol.CrearRol("admin2", "Administrador del Sistema 2");
        }

        // andres
    }
}
