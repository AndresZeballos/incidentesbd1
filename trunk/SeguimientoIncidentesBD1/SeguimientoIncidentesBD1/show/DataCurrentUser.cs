﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeguimientoIncidentesBD1;
using SeguimientoIncidentesBD1.persist;
using SeguimientoIncidentesBD1.logic;

namespace WindowsFormsASeguimientoIncidentesBD1.show
{
    public class DataCurrentUser
    {

        private static DataCurrentUser currentUser;
        private static Usuario_Logic current;

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
    }
}
