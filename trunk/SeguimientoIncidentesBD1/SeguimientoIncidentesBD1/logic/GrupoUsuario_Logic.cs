using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class GrupoUsuario_Logic
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

        public IList<string> UsuGrpUsuCod
        {
            get { return usuGrpCod; }
            set { usuGrpCod = value; }
        }

        public GrupoUsuario_Logic(string grpUsuCod, string grpUsuDes)
        {
            this.grpUsuCod = grpUsuCod;
            this.grpUsuDes = grpUsuDes;
        }

        public GrupoUsuario_Logic(string grpUsuCod)
        {
            try
            {
                GrupoUsuario_Persist grupo = new GrupoUsuario_Persist(grpUsuCod);
                this.grpUsuCod = grpUsuCod;
                this.grpUsuDes = grupo.GrpUsuDes;
                this.usuGrpCod = grupo.UsuGrpCod;
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
                GrupoUsuario_Persist grupo = new GrupoUsuario_Persist(this.grpUsuCod, this.grpUsuDes);
                grupo.GrupoUsuarioCreate();
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void GrupoUsuarioDelete()
        {
            try
            {
                GrupoUsuario_Persist grupo = new GrupoUsuario_Persist(this.grpUsuCod);
                grupo.GrupoUsuarioDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void GrpUsuDeleteUser(string user)
        {
            try
            {
                GrupoUsuario_Persist grupo = new GrupoUsuario_Persist(this.grpUsuCod);
                grupo.GrpUsuDeleteUser(user);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }


        //actualiza la descripción de un grupo de usuarios
        public void GrupoUsuarioDesUpdate(string nuevaDesc)
        {
            try
            {
                GrupoUsuario_Persist grpPersist = new GrupoUsuario_Persist(this.grpUsuCod);
                //actualizo la nueva descripción
                grpPersist.GrpUsuDeleteUser(nuevaDesc);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //agrega una nueva seguridad relacionada al rol
        public void GrpUsuAdd(string usuCod)
        {
            try
            {
                //actualizo la lista de seguridades
                this.usuGrpCod.Add(usuCod);
                GrupoUsuario_Persist grpPersist = new GrupoUsuario_Persist(this.grpUsuCod);
                grpPersist.GrpUsuUsuAdd(usuCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //agrega una nueva seguridad relacionada al rol
        public void GrpUsuAddAll(IList<string> usuCod)
        {
            try
            {
                //actualizo la lista de seguridades
                this.usuGrpCod = usuCod;
                GrupoUsuario_Persist grpPersist = new GrupoUsuario_Persist(this.grpUsuCod);
                grpPersist.GrpUsuUsuAddAll(usuCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
