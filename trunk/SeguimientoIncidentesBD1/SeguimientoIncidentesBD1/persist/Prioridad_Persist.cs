using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        public Prioridad_Persist(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        internal void PrioridadCreate()
        {
            throw new NotImplementedException();
        }

        internal void PrioridadDelete()
        {
            throw new NotImplementedException();
        }
    }
}
