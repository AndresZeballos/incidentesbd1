using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    class Severidad_Persist
    {
        private string sevCod;

        public string SevCod
        {
            get { return sevCod; }
            set { sevCod = value; }
        }

        public Severidad_Persist(string sevCod)
        {
            // TODO: Complete member initialization
            this.sevCod = sevCod;
        }

        public Severidad_Persist()
        {
            //constructor vacio para utilizar el categoría existe
        }

        public bool SeveridadExiste(string sevCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM severidad WHERE sevCod = @sevCod";
                sql.Parameters.AddWithValue("@sevCod", sevCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["severidad"];
                return (dt.Rows[0].Field<string>("sevCod") != null);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void SeveridadDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "DELETE FROM severidad WHERE sevCod = @sevCod";
                sql.Parameters.AddWithValue("@sevCod", this.sevCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void SeveridadCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO severidad (sevCod) VALUES (@sevCod)";
                sql.Parameters.AddWithValue("@sevCod", this.sevCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
