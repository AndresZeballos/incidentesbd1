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

        public Severidad_Persist(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }
        internal void SeveridadDelete()
        {
            throw new NotImplementedException();
        }

        internal void SeveridadCreate()
        {
            throw new NotImplementedException();
        }
    }
}
