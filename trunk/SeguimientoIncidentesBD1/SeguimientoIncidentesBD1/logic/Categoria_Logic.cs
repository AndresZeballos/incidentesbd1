using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Categoria_Logic
    {
        private string catCod;

        public string CatCod
        {
            get { return catCod; }
            set { catCod = value; }
        }

        public Categoria_Logic(string catCod)
        {
            this.catCod = catCod;
        }

        public bool CategoriaExiste(string catCod)
        {
            try
            {
                Categoria_Persist cat = new Categoria_Persist();
                return cat.CategoriaExiste(catCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void CategoriaPersist()
        {
            try
            {
                Categoria_Persist cat = new Categoria_Persist(this.catCod);
                cat.CategoriaCreate();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
        
        public void CategoriaDelete()
        {
            try
            {
                Categoria_Persist cat = new Categoria_Persist(this.catCod);
                cat.CategoriaDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
