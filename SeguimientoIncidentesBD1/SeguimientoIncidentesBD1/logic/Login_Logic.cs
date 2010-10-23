using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Login_Logic
    {
        public Login_Logic()
        {
        }

        public bool ValidarLogin(string usuCod, string usuPass)
        {
            try
            {
                Usuario_Logic usu = new Usuario_Logic(usuCod);
                return (usu.UsuPass == usuPass);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
