using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    class SQLSelect
    {
        public SQLSelect()
        { }

        public DataSet Execute(SqlCommand cmd)
        {
            try
            {
                Conexion cnx = new Conexion();

                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
