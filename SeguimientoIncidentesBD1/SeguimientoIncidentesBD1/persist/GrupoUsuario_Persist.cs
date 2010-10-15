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
        private string p;
        private string p_2;
        private IList<string> iList;

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

        public GrupoUsuario_Persist(string grpUsuCod)
        {
            // TODO: Complete member initialization
            this.grpUsuCod = grpUsuCod;
        }

        public GrupoUsuario_Persist(string p, string p_2, IList<string> iList)
        {
            // TODO: Complete member initialization
            this.p = p;
            this.p_2 = p_2;
            this.iList = iList;
        }

        internal void GrupoUsuarioCreate()
        {
            throw new NotImplementedException();
        }

        internal void GrupoUsuarioDelete()
        {
            throw new NotImplementedException();
        }
    }
}
