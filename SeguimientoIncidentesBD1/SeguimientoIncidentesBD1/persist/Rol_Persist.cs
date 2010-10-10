using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;


namespace SeguimientoIncidentesBD1.persist
{
    class Rol_Persist
    {
        private string rolCod;
        private string rolDesc;
        private IList<string> rolSegCod;

        public string RolCod
        {
            get { return rolCod; }
            set { rolCod = value; }
        }

        public string RolDesc
        {
            get { return rolDesc; }
            set { rolDesc = value; }
        }

        public Rol_Persist(string rolCod, string rolDesc)
        {
            this.rolCod = rolCod;
            this.rolDesc = rolDesc;
        }

        //este al recibir el rolCod debe hacer una busqueda en la BD y traer los datos
        public Rol_Persist(string rolCod)
        {
            try
            {
                this.rolCod = rolCod;
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM roles WHERE rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["roles"];
                int i = 0;
                foreach (DataRow drow in dt.Rows)
                {
                    this.rolSegCod[i] = drow.Field<string>("rolSegCod");
                    i++;
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        /*los parametros van marcados con @*/

        /* Con el SQLCommandBuilder se persisten los cambios hechos en un DataSet en la
         * correspondiente tabla en nuestra base de datos, sin tener que armar el insert, update
         * o delete manualmente
         * 
         * Para su uso hay que usar el objeto GridView
         */
        public void RolCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                foreach (string rolSeg in this.rolSegCod)
                {
                    sql.CommandText = "INSERT INTO roles (rolCod, rolDes, rolSegCod) VALUES (@rolCod, @rolDes, @rolSegCod)";
                    sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                    sql.Parameters.AddWithValue("@rolDes", this.rolDesc);
                    //la base de datos debería controlar que el id exista en la tabla de seguridades
                    sql.Parameters.AddWithValue("@rolSegCod", rolSeg);
                    SQLExecute sqlIns = new SQLExecute();
                    sqlIns.Execute(sql);
                }
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }

        internal void RolDescUpdate(string rolCod, string nuevaDesc)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE roles SET rolDesc = @rolDesc WHERE rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                sql.Parameters.AddWithValue("@rolDesc", this.rolDesc);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        internal void RolSegCodAdd(int rolSeg)
        {
            throw new NotImplementedException();
        }

        internal void RolDelete()
        {
            throw new NotImplementedException();
        }

        internal void RolCreate(string p, string p_2)
        {
            throw new NotImplementedException();
        }

        internal void RolDescUpdate(string nuevaDesc)
        {
            throw new NotImplementedException();
        }
    }
}
