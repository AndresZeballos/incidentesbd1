using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    class SQLExecute
    {
        public SQLExecute() { }
        
        //corregir para que devuelva un array conteniendo lo que devuelva la consulta
        public bool Execute(SqlCommand cmd)
        {
            try
            {
                Conexion cnx = new Conexion();
                cmd.Connection = cnx.Connection;

                SqlDataReader dr;
                cnx.Connection.Open();
                dr = cmd.ExecuteReader();
                cnx.Connection.Close();
                return true;
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("Error al ejecutar la sentencia:" + ex.Message);
                return false;
            }
        }
    }
}
