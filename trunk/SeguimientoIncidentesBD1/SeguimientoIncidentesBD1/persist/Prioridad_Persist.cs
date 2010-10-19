using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    class Prioridad_Persist
    {
        private string priCod;

        public string PriCod
        {
            get { return priCod; }
            set { priCod = value; }
        }

        public Prioridad_Persist(string priCod)
        {
            // TODO: Complete member initialization
            this.priCod = priCod;
        }

        public Prioridad_Persist()
        {
            //constructor vacio para usar PrioridadExiste
        }

        public bool PrioridadExiste(string priCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM prioridad WHERE priCod = @priCod";
                sql.Parameters.AddWithValue("@priCod", priCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["prioridad"];
                return (dt.Rows[0].Field<string>("priCod") != null);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void PrioridadCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO prioridad (priCod) VALUES (@priCod)";
                sql.Parameters.AddWithValue("@priCod", this.priCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void PrioridadDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "DELETE FROM prioridad WHERE priCod = @priCod";
                sql.Parameters.AddWithValue("@priCod", this.priCod);
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
