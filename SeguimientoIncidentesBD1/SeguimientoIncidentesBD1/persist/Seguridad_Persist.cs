using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class Seguridad_Persist
    {
        private string segCod;
        private string segDes;

        public string SegCod
        {
            get { return segCod; }
            set { segCod = value; }
        }

        public string SegDes
        {
            get { return segDes; }
            set { segDes = value; }
        }

        public Seguridad_Persist(string segCod, string segDes)
        {
            this.segCod = segCod;
            this.segDes = segDes;
        }

        public Seguridad_Persist(string segCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM seguridad WHERE segCod = @segCod";
                sql.Parameters.AddWithValue("@segCod", this.segCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "seguridad");
                DataTable dt = ds.Tables["seguridad"];
                this.segCod = dt.Rows[0].Field<string>("segCod");
                this.segDes = dt.Rows[0].Field<string>("segDes");
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
            
        }

        public void SeguridadCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO seguridad (segCod, segDes) VALUES (@segCod, @segDes)";
                sql.Parameters.AddWithValue("@segCod", this.segCod);
                sql.Parameters.AddWithValue("@segDes", this.segDes);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "seguridad");
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void SeguridadDelete(string segCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "DELETE FROM seguridad WHERE segCod = @segCod";
                sql.Parameters.AddWithValue("@segCod", segCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "seguridad");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            
        }

        public void SeguridadDesUpdate(string nuevaDesc)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE seguridad SET segDes = @segDes WHERE segCod = @segCod";
                sql.Parameters.AddWithValue("@segCod", this.segCod);
                sql.Parameters.AddWithValue("@segDes", nuevaDesc);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "seguridad");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
