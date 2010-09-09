using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    class Rol
    {
        private String rolCod;
        private String rolDes;

        public Rol()
        {
        }

        public void CrearRol(String rolCod, String rolDes)
        {
            this.rolCod = rolCod;
            this.rolDes = rolDes;
            SqlCommandBuilder sqlcmd = new SqlCommandBuilder();
            /*Ejemplo de sql command
             * SQLCommand sql = new SQLCommand();
             * sql.CommandText = "INSERT INTO roles (rolCod, rolDes) VALUES (@rolCod, @rolDes)
             * sql.Parameters["@rolCod"] = rolCod;
             * sql.Parameters["@rolDes"] = rolDes;
             * los parametros van marcados con @
             */

            /* Con el SQLCommandBuilder se persisten los cambios hechos en un DataSet en la
             * correspondiente tabla en nuestra base de datos, sin tener que armar el insert, update
             * o delete manualmente
             * 
             * Para su uso hay que usar el objeto GridView
             */
            
            String cons = "INSERT INTO roles (rolCod, rolDes) VALUES ('" + rolCod + "', '" + rolDes + "')";

            SQLInsert sql = new SQLInsert();
            sql.Execute(cons);
        }
    }
}
