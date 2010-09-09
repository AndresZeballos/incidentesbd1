using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    class SQLInsert
    {
        private String cons;

        public SQLInsert() { }
        
        public bool Execute(String cons)
        {
            Conexion cnx = new Conexion();

            this.cons = cons;
            
            SqlCommand cmd = new SqlCommand("", cnx.Connection);
            cmd.CommandText = cons;
            
            SqlDataReader dr;
            cnx.Connection.Open();
            dr = cmd.ExecuteReader();
            cnx.Connection.Close();

            return true;
        }
    }
}
