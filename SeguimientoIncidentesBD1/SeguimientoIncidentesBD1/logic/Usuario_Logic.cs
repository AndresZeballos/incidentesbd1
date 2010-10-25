using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Usuario_Logic
    {
        private string usuCod;
        private string usuPass;
        private string usuNom;
        private string usuMail;
        private IList<string> usuRol = new List<string>();
        private IList<string> usuSeg = new List<string>();

        public string UsuCod
        {
            get{return usuCod;}
            set{usuCod = value;}
        }

        public string UsuPass
        {
            get{return usuPass;}
            set{usuPass = value;}
        }

        public string UsuNom
        {
            get{return usuNom;}
            set{usuNom = value;}
        }

        public string UsuMail
        {
            get{return usuMail;}
            set{usuMail = value;}
        }

        public IList<string> UsuRol
        {
            get{return usuRol;}
            set{usuRol = value;}
        }

        public IList<string> UsuSeg
        {
            get { return usuSeg; }
            set { usuSeg = value; }
        }

        public Usuario_Logic(string usuCod, string usuNom, string usuPass, string usuMail)
        {
            this.usuCod = usuCod;
            this.usuNom = usuNom;
            this.usuPass = usuPass;
            this.usuMail = usuMail;
        }

        //cada entidad debe tener un constructor que solo reciba la clave, y en dicho caso haga la busqueda en la BD
        //y cargue los datos a partir de los datos del usuario en la base
        public Usuario_Logic(string usuCod)
        {
            try
            {
                Usuario_Persist usuPersist = new Usuario_Persist(usuCod);
                this.usuCod = usuPersist.UsuCod;
                this.usuNom = usuPersist.UsuNom;
                this.usuPass = usuPersist.UsuPass;
                this.usuMail = usuPersist.UsuMail;
                this.usuRol = usuPersist.UsuRol;
                this.usuSeg = usuPersist.UsuSeg;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //persiste un rol en la base de datos
        public void UsuarioPersist()
        {
            try
            {
                Usuario_Persist usuPersist = new Usuario_Persist(this.usuCod, this.usuNom, this.usuPass, this.usuMail);
                usuPersist.UsuarioCreate();
            }
            catch (SqlException sqlex)
            {
                //el metodo CrearRol de la clase Usuario_Persist debe hacer un throw de la excepcion en caso de que no
                //se pueda persistir el rol en la base de datos.
                //ESTE MANEJO DE EXPCECIONES DEBE REALIZARSE SIEMPRE
                throw sqlex;
            }
        }

        //persiste un rol en la base de datos
        public void UsuarioDelete()
        {
            try
            {
                Usuario_Persist usuPersist = new Usuario_Persist(this.usuCod);
                usuPersist.UsuarioDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //actualiza los diferentes atributos del usuario, menos sus roles
        public void UsuarioUpdate(string usuNom, string usuPass, string usuMail)
        {
            try
            {
                this.usuNom = usuNom;
                this.usuPass = usuPass;
                this.usuMail = usuMail;
                Usuario_Persist usuPersist = new Usuario_Persist(this.usuCod);
                //actualizo los nuevos datos
                usuPersist.UsuarioUpdate(this.usuNom, this.usuPass, this.usuMail);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void UsuarioRolDelete(string rolCod)
        {
            try
            {
                //actualizo la lista de roles
                this.usuRol.Add(rolCod);
                Usuario_Persist usuPersist = new Usuario_Persist(this.usuCod);
                usuPersist.UsuarioRolDelete(rolCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //agrega un nuevo rol al usuario
        public void UsuarioRolAdd(string rolCod)
        {
            try
            {
                //actualizo la lista de roles
                this.usuRol.Add(rolCod);
                Usuario_Persist usuPersist = new Usuario_Persist(this.usuCod);
                usuPersist.UsuarioRolAdd(rolCod);              
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //agrega los roles del usuario
        public void UsuarioRolAddAll(IList<string> rolCod)
        {
            try
            {
                //actualizo la lista de roles
                this.usuRol = rolCod;
                Usuario_Persist usuPersist = new Usuario_Persist(this.usuCod);
                usuPersist.UsuarioRolAddAll(rolCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
