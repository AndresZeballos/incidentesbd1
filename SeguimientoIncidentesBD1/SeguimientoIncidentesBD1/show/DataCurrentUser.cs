﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeguimientoIncidentesBD1;
using SeguimientoIncidentesBD1.persist;
using SeguimientoIncidentesBD1.logic;
using System.Data;

namespace WindowsFormsASeguimientoIncidentesBD1.show
{
    public class DataCurrentUser
    {

        private static DataCurrentUser currentUser;
        private static Usuario_Logic current;
        private static Incidente_Logic incidente;
        private static string currentProject;
        private static string currentIncident;

        public static DataCurrentUser getInstance()
        {
            if (currentUser == null)
            {
                currentUser = new DataCurrentUser(current);
            }
            return currentUser;
        }

        private DataCurrentUser(Usuario_Logic user) {
            current = user;
        }

        public static bool validarUsuario(string usuCod, string usuPass)
        {
            current = new Usuario_Logic(usuCod);
            if (current != null)
            {
                if (current.UsuPass == usuPass)
                {
                    currentUser = getInstance();
                    return true;
                }
            }
            return false;
        }

        public static bool validarSeguridad(string seguridad)
        {
            return current.UsuSeg.Contains(seguridad);
        }

        public static void actualizarUsuario(string usuNom, string usuPass, string usuMail)
        {
            current.UsuarioUpdate(usuNom, usuPass, usuMail);
        }

        public static void cargarProyecto(string proCod)
        {
            currentProject = proCod;
        }

        public static string proyectoActual()
        {
            return currentProject;
        }

        public static void cargarIncidente(string incCod)
        {
            currentIncident = incCod;
        }

        public static string incidenteActual()
        {
            return currentIncident;
        }

        public static Incidente_Logic verIncidente()
        {
            int incCodNum = Int32.Parse(currentIncident);
            incidente = new Incidente_Logic(incCodNum);
            int curProNum = Int32.Parse(currentProject);
            if (incidente.IncProCod != incCodNum)
                incidente = null;
            return incidente;
        }

        public void ingresarIncidente(string incRes, string incDes, string incPri, string incSev, string incCat, string incUsuAsig)
		{
			
		}
		
		

    }
}
