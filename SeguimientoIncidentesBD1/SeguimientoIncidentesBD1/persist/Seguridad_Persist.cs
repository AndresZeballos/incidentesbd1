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
                this.segCod = segCod;
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM seguridades WHERE segCod = @segCod";
                sql.Parameters.AddWithValue("@segCod", this.segCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["seguridades"];
                this.segDes = dt.Rows[0].Field<string>("segDes");
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
                sql.CommandText = "INSERT INTO seguridad (segCod, segDes) VALUES (@segCod, @segDes)";
                sql.Parameters.AddWithValue("@segCod", this.segCod);
                sql.Parameters.AddWithValue("@segDes", this.segDes);
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

        internal void SegCodAdd(string seg)
        {
            throw new NotImplementedException();
        }
    }
}
