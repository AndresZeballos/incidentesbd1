using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SeguimientoIncidentesBD1.persist
{
    class Categoria_Persist
    {
        private string catCod;

        public string CatCod
        {
            get { return catCod; }
            set { catCod = value; }
        }

        public Categoria_Persist(string p)
        {
            // TODO: Complete member initialization
            this.p = p;
        }

        internal void CategoriaCreate()
        {
            throw new NotImplementedException();
        }

        internal void CategoriaDelete()
        {
            throw new NotImplementedException();
        }
    }
}
