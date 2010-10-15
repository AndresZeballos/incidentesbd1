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

        public GrupoUsuario_Logic(string grpUsuCod, string grpUsuDes, IList<string> usuGrpUsuCod)
        {
            this.grpUsuCod = grpUsuCod;
            this.grpUsuDes = grpUsuDes;
            this.usuGrpUsuCod = usuGrpUsuCod;
        }

        public GrupoUsuario_Logic(string grpUsuCod)
        {
            try
            {
                this.grpUsuCod = grpUsuCod;
                GrupoUsuario_Persist grupo = new GrupoUsuario_Persist(grpUsuCod);
                this.grpUsuDes = grupo.GrpUsuDes;
                this.usuGrpUsuCod = grupo.UsuGrpUsuCod;
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
                GrupoUsuario_Persist grupo = new GrupoUsuario_Persist(this.grpUsuCod, this.grpUsuDes, 
                    this.usuGrpUsuCod);
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

        public void GrupoUsuarioDes

    }
}
