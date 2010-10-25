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
        private IList<string> rolSeg = new List<string>();

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

        public Rol_Persist(string rolCod, string rolDes)
        {
            this.rolCod = rolCod;
            this.rolDes = rolDes;
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
                DataSet ds = sqlIns.Execute(sql, "rol");
                DataTable dt = ds.Tables["rol"];
                this.rolCod = dt.Rows[0].Field<string>("rolCod");
                //cargo la descripción del rol
                this.rolDes = dt.Rows[0].Field<string>("rolDes");
                sql.CommandText = "SELECT * FROM rolSeguridad WHERE rolCod = @rolCod";
                sql.Parameters.Clear();
                sql.Parameters.AddWithValue("@rolCod", rolCod);
                SQLExecute sqlInsRolSeg = new SQLExecute();
                DataSet dsRolSeg = sqlInsRolSeg.Execute(sql, "rolSeguridad");
                DataTable dtRolSeg = dsRolSeg.Tables["rolSeguridad"];
                foreach (DataRow drow in dtRolSeg.Rows)
                {                    
                    this.rolSeg.Add(drow.Field<string>("rolSegCod"));
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
                sqlIns.Execute(sql, "rol");                
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
                this.rolDes = nuevaDesc;
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE rol SET rolDes = @rolDes WHERE rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                sql.Parameters.AddWithValue("@rolDes", nuevaDesc);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "rol");
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
                this.rolSeg.Add(segCod);
                SqlCommand sql = new SqlCommand();               
                sql.CommandText = "INSERT INTO rolSeguridad (rolCod, rolSegCod) VALUES (@rolCod, @rolSegCod)";
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                sql.Parameters.AddWithValue("@rolSegCod", segCod);
                SQLExecute sqlInsSeg = new SQLExecute();
                sqlInsSeg.Execute(sql, "rolSeguridad");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void RolDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                //elimino primero las asociaciones del rol con seguridades
                sql.CommandText = "DELETE FROM rolSeguridad WHERE rolSeguridad.rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "rolSeguridad");
                sql.Parameters.Clear();

                //elimino primero las asociaciones del rol con usuarios
                sql.CommandText = "DELETE FROM usuarioRol WHERE usuarioRol.usuRolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql, "usuarioRol");
                sql.Parameters.Clear();

                //elimino el rol propiamente dicho
                sql.Parameters.Clear();
                sql.CommandText = "DELETE FROM rol WHERE rol.rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                SQLExecute sqlIns3 = new SQLExecute();
                sqlIns3.Execute(sql, "rol");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void RolSegDelete(string segCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                //elimino primero las asociaciones del rol con seguridades
                sql.CommandText = "DELETE FROM rolSeguridad WHERE rolSeguridad.rolCod = @rolCod " +
                                    "AND rolSeguridad.rolSegCod = @segCod";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                sql.Parameters.AddWithValue("@segCod", segCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "rolSeguridad");
                sql.Parameters.Clear();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void RolSegAddAll(IList<string> rolSeg)
        {
            this.rolSeg = rolSeg;
            //hago la consulta sobre la tabla rolSeguridad
            SqlCommand sql = new SqlCommand();
            //agrego las seguridades del rol
            sql.CommandText = "INSERT INTO rolSeguridad (rolCod, rolSegCod) VALUES (@rolCod, @rolSegCod)";
            //la base de datos debería controlar que el id exista en la tabla de seguridades
            sql.Parameters.AddWithValue("@rolCod", "");
            sql.Parameters.AddWithValue("@rolSegCod", "");
            sql.Parameters[0].Value = this.rolCod;
            foreach (string rolSegCodActual in this.rolSeg)
            {
                sql.Parameters[1].Value = rolSegCodActual;
                SQLExecute sqlInsSeg = new SQLExecute();
                sqlInsSeg.Execute(sql, "rolSeguridad");
            }
        }
    }
}
