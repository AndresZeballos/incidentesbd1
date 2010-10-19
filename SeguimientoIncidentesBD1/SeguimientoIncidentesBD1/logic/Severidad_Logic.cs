using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Severidad_Logic
    {
        private string sevCod;

        public string SevCod
        {
            get { return sevCod; }
            set { sevCod = value; }
        }

        public Severidad_Logic(string sevCod)
        {
            this.sevCod = sevCod;
        }

        public bool SeveridadExiste(string sevCod)
        {
            try
            {
                Severidad_Persist sev = new Severidad_Persist();
                return sev.SeveridadExiste(sevCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void SeveridadPersist()
        {
            try
            {
                Severidad_Persist sev = new Severidad_Persist(this.sevCod);
                sev.SeveridadCreate();
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
                Severidad_Persist sev = new Severidad_Persist(this.sevCod);
                sev.SeveridadDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
