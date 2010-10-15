using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Estado_Logic
    {
        private string estCod;

        public string EstCod
        {
            get { return estCod; }
            set { estCod = value; }
        }

        public Estado_Logic(string estCod)
        {
            this.estCod = estCod;
        }

        public void EstadoPersist()
        {
            try
            {
                Estado_Persist est = new Estado_Persist(this.estCod);
                est.EstadoCreate();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
        
        public void EstadoDelete()
        {
            try
            {
                Estado_Persist est = new Estado_Persist(this.estCod);
                est.EstadoDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
