using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeguimientoIncidentesBD1.persist
{
    class Estado_Persist
    {
        private string estCod;

        public string EstCod
        {
            get { return estCod; }
            set { estCod = value; }
        }

        public Estado_Persist(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        internal void EstadoCreate()
        {
            throw new NotImplementedException();
        }

        internal void EstadoDelete()
        {
            throw new NotImplementedException();
        }

        internal void PrioridadDelete()
        {
            throw new NotImplementedException();
        }
    }
}
