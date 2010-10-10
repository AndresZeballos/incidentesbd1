using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class RolSeguridad_Logic
    {
        private string rolCod;
        private string[] rolSeg;

        public string RolCod
        {
            get { return rolCod; }
            set { rolCod = value; }
        }

        public string[] RolSeg
        {
            get { return rolSeg; }
            set { rolSeg = value; }
        }

        public RolSeguridad_Logic(string rolCod, string[] rolSeg)
        {
            this.rolCod = rolCod;
            this.rolSeg = rolSeg;
        }
        
        //si se le pasa solo el rolCod, busca las seguridades y las devuelve
        public RolSeguridad_Logic(string rolCod)
        {
            try
            {
                this.rolCod = rolCod;
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM roles WHERE rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", rolCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["roles"];
                int i = 0;
                foreach (DataRow drow in dt.Rows)
                {
                    this.rolSeg[i] = drow.Field<string>("rolSeg");
                    i++;
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        internal void RolSeguridadPersist()
        {
            throw new NotImplementedException();
        }

        internal void RolSeguridadModify(string[] rolSeg)
        {
            RolSeguridad_Persist rolSegPersist = new RolSeguridad_Persist();
            Seguridad_Persist segPersist = new Seguridad_Persist("");
            try
            {
                //luego comparo uno a uno los rolSeg, si no existe, lo agrego
                foreach (string seg in rolSeg)
                {
                    Boolean rolExiste = false;
                    foreach (string rolSegExistente in this.rolSeg)
                    {
                        if (seg == rolSegExistente)
                        {
                            rolExiste = true;
                            break;
                        }
                    }
                    if (!rolExiste)
                    {
                        segPersist.SegCodAdd(seg);
                        rolSegPersist.RolSegCodAdd(this.rolCod, seg);
                    }
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
