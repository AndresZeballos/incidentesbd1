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
        private int[] rolSegId;

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

        public int[] RolSegId
        {
            get { return rolSegId; }
            set { rolSegId = value; }
        }

        public Rol_Persist(string rolCod, string rolDesc, int[] rolSegId)
        {
            this.rolCod = rolCod;
            this.rolDesc = rolDesc;
            this.rolSegId = rolSegId;
        }

        //este al recibir el rolCod debe hacer una busqueda en la BD y traer los datos
        public Rol_Persist(string rolCod)
        {
        }

        public void RolCreate()
        {
            SqlCommand sql = new SqlCommand();
            foreach (int rolSeg in this.rolSegId)
            {
                sql.CommandText = "INSERT INTO roles (rolCod, rolDes, rolSegId) VALUES (@rolCod, @rolDes, @rolSegId)";
                sql.Parameters.AddWithValue("@rolCod", this.rolCod);
                sql.Parameters.AddWithValue("@rolDes", this.rolDesc);
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@rolSegId", rolSeg);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
            }
            /*los parametros van marcados con @*/

            /* Con el SQLCommandBuilder se persisten los cambios hechos en un DataSet en la
             * correspondiente tabla en nuestra base de datos, sin tener que armar el insert, update
             * o delete manualmente
             * 
             * Para su uso hay que usar el objeto GridView
             */
        }

        internal void RolDescUpdate(string nuevaDesc)
        {
            throw new NotImplementedException();
        }

        internal void RolSegIdAdd(int rolSeg)
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
    }
}
