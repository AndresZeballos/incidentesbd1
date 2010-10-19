using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class GrupoUsuario_Persist
    {
        private string grpUsuCod;
        private string grpUsuDes;
        private IList<string> usuGrpUsuCod;

        public string GrpUsuCod
        {
            get { return grpUsuCod; }
            set { grpUsuCod = value; }
        }

        public string GrpUsuDes
        {
            get { return grpUsuDes; }
            set { grpUsuDes = value; }
        }

        public IList<string> UsuGrpUsuCod
        {
            get { return usuGrpUsuCod; }
            set { usuGrpUsuCod = value; }
        }

        public GrupoUsuario_Persist(string grpUsuCod, string grpUsuDes, IList<string> usuGrpUsuCod)
        {
            this.grpUsuCod = grpUsuCod;
            this.grpUsuDes = grpUsuDes;
            this.usuGrpUsuCod = usuGrpUsuCod;
        }

        public GrupoUsuario_Persist(string grpUsuCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM grupoUsuario WHERE grpUsuCod = @grpUsuCod";
                sql.Parameters.AddWithValue("@grpUsuCod", grpUsuCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["grupoUsuario"];
                this.grpUsuCod = dt.Rows[0].Field<string>("grpUsuCod");
                //cargo la descripción del grupo de usuarios
                this.grpUsuDes = dt.Rows[0].Field<string>("grpUsuDes");
                //hago la consulta sobre la tabla usuarioGrupoUsuario
                sql.Parameters.Clear();
                sql.CommandText = "SELECT * FROM usuarioGrupoUsuario WHERE grpUsuCod = @grpUsuCod";
                sql.Parameters.AddWithValue("@grpUsuCod", this.grpUsuCod);
                SQLExecute sqlInsGrpUsu = new SQLExecute();
                DataSet dsGrpUsu = sqlInsGrpUsu.Execute(sql);
                DataTable dtGrpUsu = dsGrpUsu.Tables["usuarioGrupoUsuario"];
                int i = 0;
                foreach (DataRow drow in dtGrpUsu.Rows)
                {

                    this.usuGrpUsuCod[i] = drow.Field<string>("usuGrpUsuCod");
                    i++;
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void GrupoUsuarioCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO grupoUsuario (grpUsuCod, grpUsuDes) VALUES (@grpUsuCod, @grpUsuDes)";
                sql.Parameters.AddWithValue("@grpUsuCod", this.grpUsuCod);
                sql.Parameters.AddWithValue("@grpUsuDes", this.grpUsuDes);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
                sql.Parameters.Clear();
                //agrego las seguridades del rol
                sql.CommandText = "INSERT INTO usuarioGrupoUsuario (grpUsuCod, usuGrpUsuCod) VALUES (@grpUsuCod, @usuGrpUsuCod)";
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@grpUsuCod", "");
                sql.Parameters.AddWithValue("@usuGrpUsuCod", "");
                sql.Parameters[0].Value = this.grpUsuCod;
                foreach (string usuGrpUsuCodActual in this.usuGrpUsuCod)
                {
                    sql.Parameters[1].Value = usuGrpUsuCodActual;
                    SQLExecute sqlGrpUsu = new SQLExecute();
                    sqlGrpUsu.Execute(sql);
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void GrupoUsuarioDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                //elimino primero las asociaciones de los usuarios con el grupo de usuarios
                sql.CommandText = "DELETE FROM usuarioGrupoUsuario WHERE grpUsuCod=@grpUsuCod";
                sql.Parameters.AddWithValue("@grpUsuCod", this.grpUsuCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
                sql.Parameters.Clear();
                //elimino el grupo de usuarios propiamente dicho
                sql.Parameters.Clear();
                sql.CommandText = "DELETE FROM	grupoUsuario WHERE grpUsuCod=@grpUsuCod";
                sql.Parameters.AddWithValue("@grpUsuCod", this.grpUsuCod;
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void GrpUsuDesUpdate(string nuevaDesc)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE grupoUsuario SET grpUsuDes = @grpUsuDes WHERE grpUsuCod = @grpUsuCod";
                sql.Parameters.AddWithValue("@grpUsuCod", this.grpUsuCod);
                sql.Parameters.AddWithValue("@grpUsuDes", nuevaDesc);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void GrpUsuUsuAdd(string usuCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO usuarioGrupoUsuario (grpUsuCod, usuGrpUsuCod) VALUES (@grpUsuCod, @usuCod)";
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@grpUsuCod", this.grpUsuCod);
                sql.Parameters.AddWithValue("@usuCod", usuCod);
                SQLExecute sqlInsSeg = new SQLExecute();
                sqlInsSeg.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
