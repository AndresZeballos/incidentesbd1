using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class IncidenteHistoria_Persist
    {
        private int incHistCod;
        private int incHistIncCod;
        //estado de inicio de la historia
        private string incHistEstIni;
        //estado de fin de la historia
        private string incHistEstFin;
        //fecha de la historia
        private DateTime incHistFec;
        private string incHistAcc;
        private string incHistUsuCod;
        private string incHistNota;
        private int incHistTiempo;

        public int IncHistCod {get; set;}
        public int IncHistIncCod { get; set; }
        public string IncHistEstIni { get; set; }
        public string IncHistEstFin { get; set; }
        public DateTime IncHistFec { get; set; }
        public string IncHistAcc { get; set; }
        public string IncHistUsuCod { get; set; }
        public string IncHistNota { get; set; }
        public int IncHistTiempo { get; set; }

        public IncidenteHistoria_Persist(
                                        int incHistCod,
                                        int incHistIncCod,
                                        string incHistEstIni,
                                        string incHistEstFin,
                                        DateTime incHistFec,
                                        string incHistAcc,
                                        string incHistUsuCod,
                                        string incHistNota,
                                        int incHistTiempo)
        {
            this.incHistCod = incHistCod;
            this.incHistIncCod = incHistIncCod;
            this.incHistEstIni = incHistEstIni;
            this.incHistEstFin = incHistEstFin;
            this.incHistFec = incHistFec;
            this.incHistAcc = incHistAcc;
            this.incHistUsuCod = incHistUsuCod;
            this.incHistNota = incHistNota;
            this.incHistTiempo = incHistTiempo;
        }

        public IncidenteHistoria_Persist(int incHistCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM historia WHERE histCod = @histCod";
                sql.Parameters.AddWithValue("@histCod", incHistCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "historia");
                DataTable dt = ds.Tables["historia"];
                //cargo los atributos del incidente
                this.incHistCod = dt.Rows[0].Field<int>("histCod");
                this.incHistIncCod = dt.Rows[0].Field<int>("histIncCod");
                this.incHistEstIni = dt.Rows[0].Field<string>("histEstIni");
                this.incHistEstFin = dt.Rows[0].Field<string>("histIncCod");
                this.incHistFec = dt.Rows[0].Field<DateTime>("histFec");
                this.incHistAcc = dt.Rows[0].Field<string>("histAcc");
                this.incHistUsuCod = dt.Rows[0].Field<string>("histUsuCod");
                this.incHistNota = dt.Rows[0].Field<string>("histNota");
                this.incHistTiempo = dt.Rows[0].Field<int>("histTiempo");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteHistoriaCreate()
        {
            throw new NotImplementedException();
        }

        public void IncidenteHistoriaDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "DELETE FROM	historia WHERE histCod=@histCod";
                sql.Parameters.AddWithValue("@histCod", this.incHistCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "historia");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
