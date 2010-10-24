using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class Usuario_Persist
    {
        private string usuCod;
        private string usuPass;
        private string usuNom;
        private string usuMail;
        private IList<string> usuRol = new List<string>();
        private IList<string> usuSeg = new List<string>();

        public string UsuCod
        {
            get { return usuCod; }
            set { usuCod = value; }
        }

        public string UsuNom
        {
            get { return usuNom; }
            set { usuNom = value; }
        }

        public string UsuPass
        {
            get { return usuPass; }
            set { usuPass = value; }
        }

        public string UsuMail
        {
            get { return usuMail; }
            set { usuMail = value; }
        }

        public IList<string> UsuRol
        {
            get { return usuRol; }
            set { usuRol = value; }
        }

        public IList<string> UsuSeg
        {
            get { return usuSeg; }
            set { usuSeg = value; }
        }

        public Usuario_Persist(string usuCod, string usuNom, string usuPass, string usuMail)
        {
            this.usuCod = usuCod;
            this.usuNom = usuNom;
            this.usuPass = usuPass;
            this.usuMail = usuMail;
        }

        public Usuario_Persist(string usuCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM usuario WHERE usuCod = @usuCod";
                sql.Parameters.AddWithValue("@usuCod", usuCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "usuario");
                DataTable dt = ds.Tables["usuario"];
                if (dt.Rows.Count != 0)
                {
                    this.usuCod = dt.Rows[0].Field<string>("usuCod");
                    //cargo los atributos del usuario
                    this.usuNom = dt.Rows[0].Field<string>("usuNom");
                    this.usuPass = dt.Rows[0].Field<string>("usuPass");
                    this.usuMail = dt.Rows[0].Field<string>("usuMail");
                    //hago la consulta sobre la tabla usuarioRol
                    sql.Parameters.Clear();
                    sql.CommandText = "SELECT * FROM usuarioRol WHERE usuCod = @usuCod";
                    sql.Parameters.AddWithValue("@usuCod", this.usuCod);
                    SQLExecute sqlIns2 = new SQLExecute();
                    DataSet ds2 = sqlIns2.Execute(sql, "usuarioRol");
                    DataTable dt2 = ds2.Tables["usuarioRol"];
                    foreach (DataRow drow in dt2.Rows)
                    {
                        this.usuRol.Add(drow.Field<string>("usuRolCod"));
                    }
                    //hago la consulta sobre la tabla de rolSeguridad para cargar las seguridades del usuario
                    //para cada rol del usuario, cargo las seguridades asociadas
                    foreach (string rol in this.usuRol)
                    {
                        sql.Parameters.Clear();
                        sql.CommandText = "SELECT * FROM rolSeguridad WHERE rolCod = @rolCod";
                        sql.Parameters.AddWithValue("@rolCod", rol);
                        SQLExecute sqlIns3 = new SQLExecute();
                        DataSet ds3 = sqlIns3.Execute(sql, "rolSeguridad");
                        DataTable dt3 = ds3.Tables["rolSeguridad"];
                        foreach (DataRow drow in dt3.Rows)
                        {
                            this.usuSeg.Add(drow.Field<string>("rolSegCod"));
                        }
                    }
                }
                else
                {
                    System.Windows.Forms.MessageBox.Show("Usuario inexistente");
                }                    
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void UsuarioCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO usuario (usuCod, usuNom, usuPass, usuMail) VALUES (@usuCod, @usuNom, @usuPass, @usuMail)";
                sql.Parameters.AddWithValue("@usuCod", this.usuCod);
                sql.Parameters.AddWithValue("@usuNom", this.usuNom);
                sql.Parameters.AddWithValue("@usuPass", this.usuPass);
                sql.Parameters.AddWithValue("@usuMail", this.usuMail);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "usuario");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void UsuarioDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                //elimino primero las asociaciones del usuario con roles
                sql.CommandText = "DELETE FROM usuarioRol WHERE usuCod=@usuCod";
                sql.Parameters.AddWithValue("@usuCod", this.usuCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "usuario");
                sql.Parameters.Clear();
                //elimino el usuario propiamente dicho
                sql.Parameters.Clear();
                sql.CommandText = "DELETE FROM usuario WHERE usuCod=@usuCod";
                sql.Parameters.AddWithValue("@usuCod", this.usuCod);
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql, "usuarioRol");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void UsuarioUpdate(string usuNom, string usuPass, string usuMail)
        {
            try
            {
                this.usuNom = usuNom;
                this.usuPass = usuPass;
                this.usuMail = usuMail;
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE usuario SET usuNom = @usuNom, usuPass = @usuPass, usuMail = @usuMail WHERE usuCod = @usuCod";
                sql.Parameters.AddWithValue("@usuCod", this.usuCod);
                sql.Parameters.AddWithValue("@usuNom", this.usuNom);
                sql.Parameters.AddWithValue("@usuPass", this.usuPass);
                sql.Parameters.AddWithValue("@usuMail", this.usuMail);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "usuario");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void UsuarioRolAdd(string rolCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO usuarioRol (usuCod, usuRolCod) VALUES (@usuCod, @usuRolCod)";
                //la base de datos debería controlar que el id exista en la tabla de roles
                sql.Parameters.AddWithValue("@usuCod", this.usuCod);
                sql.Parameters.AddWithValue("@usuRolCod", rolCod);
                SQLExecute sqlInsSeg = new SQLExecute();
                sqlInsSeg.Execute(sql, "usuarioRol");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void UsuarioRolAddAll(IList<string> rolCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                this.usuRol = rolCod;
                sql.Parameters.Clear();
                //agrego los roles del usuario
                sql.CommandText = "INSERT INTO usuarioRol (usuCod, usuRolCod) VALUES (@usuCod, @usuRolCod)";
                //la base de datos debería controlar que el id exista en la tabla de roles
                sql.Parameters.AddWithValue("@usuCod", "");
                sql.Parameters.AddWithValue("@usuRolCod", "");
                sql.Parameters[0].Value = this.usuCod;
                foreach (string usuRolCodActual in this.usuRol)
                {
                    sql.Parameters[1].Value = usuRolCodActual;
                    SQLExecute sqlInsSeg = new SQLExecute();
                    sqlInsSeg.Execute(sql, "usuarioRol");
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
