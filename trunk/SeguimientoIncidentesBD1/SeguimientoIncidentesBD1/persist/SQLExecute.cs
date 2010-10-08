﻿using System;
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
        
        public void Execute(SqlCommand cmd)
        {
            try
            {
                Conexion cnx = new Conexion();
                cmd.Connection = cnx.Connection;

                SqlDataReader dr;
                cnx.Connection.Open();
                dr = cmd.ExecuteReader();
                cnx.Connection.Close();
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
