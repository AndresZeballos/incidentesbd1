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
        private string segDesc;

        public string SegCod
        {
            get { return segCod; }
            set { segCod = value; }
        }

        public string SegDesc
        {
            get { return segDesc; }
            set { segDesc = value; }
        }

        public Seguridad_Persist(string segCod, string segDesc)
        {
            this.segCod = segCod;
            this.segDesc = segDesc;
        }

        public Seguridad_Persist(string segCod)
        {
            try
            {
                this.segCod = segCod;
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM seguridades WHERE segCod = @segCod";
                sql.Parameters.AddWithValue("@segCod", this.segCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["seguridades"];
                this.segDesc = dt.Rows[0].Field<string>("segDesc");
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
            
        }

        internal void SeguridadCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO roles (segCod, segDesc) VALUES (@segCod, @segDesc)";
                sql.Parameters.AddWithValue("@segCod", this.segCod);
                sql.Parameters.AddWithValue("@segDesc", this.segDesc);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }

        internal void SeguridadDelete(string segCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "DELETE FROM seguridades WHERE segCod = @segCod";
                sql.Parameters.AddWithValue("@segCod", this.segCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            
        }

        internal void SeguridadDescUpdate(string nuevaDesc)
        {
            throw new NotImplementedException();
        }
    }
}
