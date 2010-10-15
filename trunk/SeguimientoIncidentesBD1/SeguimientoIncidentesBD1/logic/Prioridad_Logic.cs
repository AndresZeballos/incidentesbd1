using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Prioridad_Logic
    {
        private string priCod;

        public string PriCod
        {
            get { return priCod; }
            set { priCod = value; }
        }

        public Prioridad_Logic(string priCod)
        {
            this.priCod = priCod;
        }

        public void PrioridadPersist()
        {
            try
            {
                Prioridad_Persist pri = new Prioridad_Persist(this.priCod);
                pri.PrioridadCreate();
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
                Prioridad_Persist est = new Prioridad_Persist(this.priCod);
                est.PrioridadDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
