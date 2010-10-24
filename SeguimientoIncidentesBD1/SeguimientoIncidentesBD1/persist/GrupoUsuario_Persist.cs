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
        private IList<string> usuGrpCod = new List<string>();

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

        public IList<string> UsuGrpCod
        {
            get { return usuGrpCod; }
            set { usuGrpCod = value; }
        }

        public GrupoUsuario_Persist(string grpUsuCod, string grpUsuDes)
        {
            this.grpUsuCod = grpUsuCod;
            this.grpUsuDes = grpUsuDes;
        }

        public GrupoUsuario_Persist(string grpUsuCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM grupoUsuario WHERE grpUsuCod = @grpUsuCod";
                sql.Parameters.AddWithValue("@grpUsuCod", grpUsuCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "grupoUsuario");
                DataTable dt = ds.Tables["grupoUsuario"];
                if (dt.Rows.Count != 0)
                {
                    this.grpUsuCod = dt.Rows[0].Field<string>("grpUsuCod");
                    //cargo la descripción del grupo de usuarios
                    this.grpUsuDes = dt.Rows[0].Field<string>("grpUsuDes");
                    //hago la consulta sobre la tabla usuarioGrupoUsuario
                    sql.Parameters.Clear();
                    sql.CommandText = "SELECT * FROM usuarioGrupoUsuario WHERE usuGrpCod = @usuGrpCod";
                    sql.Parameters.AddWithValue("@usuGrpCod", this.grpUsuCod);
                    SQLExecute sqlInsGrpUsu = new SQLExecute();
                    DataSet dsGrpUsu = sqlInsGrpUsu.Execute(sql, "usuarioGrupoUsuario");
                    DataTable dtGrpUsu = dsGrpUsu.Tables["usuarioGrupoUsuario"];
                    foreach (DataRow drow in dtGrpUsu.Rows)
                    {
                        this.usuGrpCod.Add(drow.Field<string>("usuGrpCod"));
                    }
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
                sqlIns.Execute(sql, "grupoUsuario");                
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
                sqlIns.Execute(sql, "usuarioGrupoUsuario");
                sql.Parameters.Clear();
                //elimino el grupo de usuarios propiamente dicho
                sql.Parameters.Clear();
                sql.CommandText = "DELETE FROM	grupoUsuario WHERE grpUsuCod=@grpUsuCod";
                sql.Parameters.AddWithValue("@grpUsuCod", this.grpUsuCod);
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql, "grupoUsuario");
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
                sqlIns.Execute(sql, "grupoUsuario");
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
                sql.CommandText = "INSERT INTO usuarioGrupoUsuario (usuGrpCod, usuGrpUsuCod) VALUES (@usuGrpCod, @usuCod)";
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@usuGrpCod", this.grpUsuCod);
                sql.Parameters.AddWithValue("@usuCod", usuCod);
                SQLExecute sqlInsSeg = new SQLExecute();
                sqlInsSeg.Execute(sql, "usuarioGrupoUsuario");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void GrpUsuUsuAddAll(IList<string> usuCod)
        {
            try
            {
                this.usuGrpCod = usuCod;
                SqlCommand sql = new SqlCommand();
                //agrego los usuarios del grupo
                sql.CommandText = "INSERT INTO usuarioGrupoUsuario (grpUsuCod, usuGrpUsuCod) VALUES (@grpUsuCod, @usuGrpUsuCod)";
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@grpUsuCod", "");
                sql.Parameters.AddWithValue("@usuGrpUsuCod", "");
                sql.Parameters[0].Value = this.grpUsuCod;
                foreach (string usuGrpUsuCodActual in this.usuGrpCod)
                {
                    sql.Parameters[1].Value = usuGrpUsuCodActual;
                    SQLExecute sqlGrpUsu = new SQLExecute();
                    sqlGrpUsu.Execute(sql, "usuarioGrupoUsuario");
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
        
    }
}
