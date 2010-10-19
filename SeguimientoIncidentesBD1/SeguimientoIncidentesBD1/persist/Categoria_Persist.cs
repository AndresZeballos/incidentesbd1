using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

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

        /// <summary>
        /// como solo se tiene un atributo, el constructor simplemente lo carga, si se necesita se puede chequear si 
        /// el elemento ya existe con el metodo CategoriaExiste
        /// </summary>
        /// <param name="catCod"></param>
        /// <returns></returns>
        public bool CategoriaExiste(string catCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM categoria WHERE catCod = @catCod";
                sql.Parameters.AddWithValue("@catCod", catCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["categoria"];
                return (dt.Rows[0].Field<string>("catCod") != null);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public Categoria_Persist()
        {
            //crea una cateogira vacia para comprobar si una cateogira existe
        }
        
        public Categoria_Persist(string catCod)
        {
            this.catCod = catCod;            
        }

        public void CategoriaCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO categoria (catCod) VALUES (@catCod)";
                sql.Parameters.AddWithValue("@catCod", this.catCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
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
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "DELETE FROM categoria WHERE catCod = @catCod";
                sql.Parameters.AddWithValue("@catCod", this.catCod);
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
