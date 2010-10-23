using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class SQLExecute
    {
        public SQLExecute() { }
        
        public DataSet Execute(SqlCommand cmd, string tabla)
        {
            try
            {
                Conexion cnx = new Conexion();
                cmd.Connection = cnx.Connection;

                //SqlDataReader dr;
                cnx.Connection.Open();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds, tabla);
                //dr = cmd.ExecuteReader();

                cnx.Connection.Close();
                return ds;
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
