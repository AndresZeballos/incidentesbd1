using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeguimientoIncidentesBD1;
using SeguimientoIncidentesBD1.persist;
using SeguimientoIncidentesBD1.logic;
using System.Data;

namespace SeguimientoIncidentesBD1.show
{
    public static class DataCurrentUser
    {
        //NO SE PUEDEN DECLARAR  VARIABLES EN UNA CLASE ESTATICA QUE NO PUEDAN SER INSTANCIADAS

        //private static DataCurrentUser currentUser;
        //private static Incidente_Logic incidente;
        //private static string currentProject;
        //private static string currentIncident;

        //public static Usuario_Logic Current { get; set; }

        //public static DataCurrentUser getInstance()
        //{
        //    if (currentUser == null)
        //    {
        //        currentUser = new DataCurrentUser(current);
        //    }
        //    return currentUser;
        //}

        //private static DataCurrentUser(Usuario_Logic user) {
        //    current = user;
        //}

        public static bool ValidarUsuario(string usuCod, string usuPass)
        {
            Usuario_Logic usuario = new Usuario_Logic(usuCod);
            
            if (usuario != null)
            {
                if (usuario.UsuPass == usuPass)
                {
                    return true;
                }
            }
            return false;
        }

        public static bool ValidarSeguridad(string seguridad, Usuario_Logic usuario)
        {
            return usuario.UsuSeg.Contains(seguridad);
        }

        //public static void ActualizarUsuario(string usuNom, string usuPass, string usuMail, Usuario_Logic usuario)
        //{
        //    usuario.UsuarioUpdate(usuNom, usuPass, usuMail);
        //}

        //public static void CargarProyecto(string proCod)
        //{
        //    currentProject = proCod;
        //}

        //public static string ProyectoActual()
        //{
        //    return currentProject;
        //}

        //public static void CargarIncidente(string incCod)
        //{
        //    currentIncident = incCod;
        //}

        //public static string IncidenteActual()
        //{
        //    return currentIncident;
        //}

        //public static Incidente_Logic VerIncidente()
        //{
        //    int incCodNum = Int32.Parse(currentIncident);
        //    incidente = new Incidente_Logic(incCodNum);
        //    int curProNum = Int32.Parse(currentProject);
        //    if (incidente.IncProCod != incCodNum)
        //        incidente = null;
        //    return incidente;
        //}
    }
}
