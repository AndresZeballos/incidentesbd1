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


        public Seguridad_Persist(string segCod, string segDesc)
        {
            this.segCod = segCod;
            this.segDesc = segDesc;
        }

        public Seguridad_Persist(string segCod)
        {
            SqlCommand sql = new SqlCommand();
            sql.CommandText = "INSERT INTO roles (segCod, segDesc) VALUES (@segCod, @segDesc)";
            sql.Parameters.AddWithValue("@segCod", this.segCod);
            sql.Parameters.AddWithValue("@segDesc", this.segDesc);
            SQLExecute sqlIns = new SQLExecute();
            sqlIns.Execute(sql);
        }
        internal void SeguridadCreate()
        {
            throw new NotImplementedException();
        }

        internal void SeguridadDelete()
        {
            throw new NotImplementedException();
        }

        internal void SeguridadDescUpdate(string nuevaDesc)
        {
            throw new NotImplementedException();
        }
    }
}
