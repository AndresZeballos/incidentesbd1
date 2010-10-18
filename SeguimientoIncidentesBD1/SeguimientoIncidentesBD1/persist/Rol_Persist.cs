using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.logic;


namespace SeguimientoIncidentesBD1.persist
{
    class Rol_Persist
    {
        private string rolCod;
        private string rolDes;
        private IList<string> rolSeg;

        public string RolCod
        {
            get { return rolCod; }
            set { rolCod = value; }
        }

        public string RolDes
        {
            get { return rolDes; }
            set { rolDes = value; }
        }

        //en el rol no necesito todos los datos de la seguridad, solo el segCod
        public IList<string> RolSeg
        {
            get { return rolSeg; }
            set { rolSeg = value; }
        }

        public Rol_Persist(string rolCod, string rolDes, IList<string>rolSeg)
        {
            this.rolCod = rolCod;
            this.rolDes = rolDes;
            this.rolSeg = rolSeg;
        }

        //este al recibir el rolCod debe hacer una busqueda en la BD y traer los datos
        public Rol_Persist(string rolCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM rol WHERE rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", rolCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["rol"];
                this.rolCod = dt.Rows[0].Field<string>("rolCod");
                //cargo la descripción del rol
                this.rolDes = dt.Rows[0].Field<string>("rolDes");
                //hago la consulta sobre la tabla rolSeguridad
                sql.CommandText = "SELECT * FROM rolSeguridad WHERE rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                SQLExecute sqlInsRolSeg = new SQLExecute();
                DataSet dsRolSeg = sqlIns.Execute(sql);
                DataTable dtRolSeg = dsRolSeg.Tables["rolSeguridad"];
                int i = 0;
                foreach (DataRow drow in dtRolSeg.Rows)
                {
                    
                    this.rolSeg[i] = drow.Field<string>("rolSeg");
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
                sql.CommandText = "INSERT INTO rol (rolCod, rolDes) VALUES (@rolCod, @rolDes)";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                sql.Parameters.AddWithValue("@rolDes", this.rolDes);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
                sql.Parameters.Clear();
                //agrego las seguridades del rol
                sql.CommandText = "INSERT INTO rolSeguridad (rolCod, rolSegCod) VALUES (@rolCod, @rolSegCod)";
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@rolCod", "");
                sql.Parameters.AddWithValue("@rolSegCod", "");
                sql.Parameters[0].Value = this.rolCod;
                foreach (string rolSegCod in this.rolSeg)
                {
                    sql.Parameters[1].Value = rolSegCod;
                    SQLExecute sqlInsSeg = new SQLExecute();
                    sqlInsSeg.Execute(sql);
                }
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void RolDesUpdate(string nuevaDesc)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE rol SET rolDes = @rolDes WHERE rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                sql.Parameters.AddWithValue("@rolDes", nuevaDesc);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        /// <summary>
        /// Este metodo recibe una seguridad y la agrega a las relaciones del rol con esa seguridad
        /// </summary>
        /// <param name="rolSeg"></param>
        public void RolSegAdd(string segCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();               
                sql.CommandText = "INSERT INTO rolSeguridad (rolCod, rolSegCod) VALUES (@rolCod, @rolSegCod)";
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                sql.Parameters.AddWithValue("@rolSegCod", segCod);
                SQLExecute sqlInsSeg = new SQLExecute();
                sqlInsSeg.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        internal void RolDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                //elimino primero las asociaciones del rol con seguridades
                sql.CommandText = "DELETE FROM rolSeguridad WHERE rolCod=@rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
                sql.Parameters.Clear();
                //elimino el rol propiamente dicho
                sql.CommandText = "DELETE FROM	rol WHERE rolCod=@rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
