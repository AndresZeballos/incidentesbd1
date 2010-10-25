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

        public int IncHistCod
        {
            get { return incHistCod; }
            set { incHistCod = value; }
        }
        public int IncHistIncCod
        {
            get { return incHistIncCod; }
            set { incHistIncCod = value; }
        }
        public string IncHistEstIni
        {
            get { return incHistEstIni; }
            set { incHistEstIni = value; }
        }
        public string IncHistEstFin
        {
            get { return incHistEstFin; }
            set { incHistEstFin = value; }
        }
        public DateTime IncHistFec
        {
            get { return incHistFec; }
            set { incHistFec = value; }
        }
        public string IncHistAcc
        {
            get { return incHistAcc; }
            set { incHistAcc = value; }
        }
        public string IncHistUsuCod
        {
            get { return incHistUsuCod; }
            set { incHistUsuCod = value; }
        }
        public string IncHistNota
        {
            get { return incHistNota; }
            set { incHistNota = value; }
        }
        public int IncHistTiempo
        {
            get { return incHistTiempo; }
            set { incHistTiempo = value; }
        }

        public IncidenteHistoria_Persist(
                                        int incHistIncCod,
                                        string incHistEstIni,
                                        string incHistEstFin,
                                        DateTime incHistFec,
                                        string incHistAcc,
                                        string incHistUsuCod,
                                        string incHistNota,
                                        int incHistTiempo)
        {
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
                this.incHistEstFin = dt.Rows[0].Field<string>("histEstFin");
                this.incHistFec = dt.Rows[0].Field<DateTime>("histFec");
                this.incHistAcc = dt.Rows[0].Field<string>("histAcc");
                this.incHistUsuCod = dt.Rows[0].Field<string>("histUsuCod");
                this.incHistNota = dt.Rows[0].Field<string>("histNota");
                this.incHistTiempo = dt.Rows[0].Field<int>("histHrs");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteHistoriaCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO historia (histIncCod, histEstIni, histEstFin, histFec, histAcc, histUsuCod, histNota,"+
                    " histHrs) VALUES (@histIncCod, @histEstIni, @histEstFin, @histFec, @histAcc, @histUsuCod, @histNota, @histHrs)";
                sql.Parameters.AddWithValue("@histIncCod", this.incHistIncCod);
                sql.Parameters.AddWithValue("@histEstIni", this.incHistEstIni);
                sql.Parameters.AddWithValue("@histEstFin", this.incHistEstFin);
                sql.Parameters.AddWithValue("@histFec", DateTimeToDateSQL(this.incHistFec));
                sql.Parameters.AddWithValue("@histAcc", this.incHistAcc);
                sql.Parameters.AddWithValue("@histUsuCod", this.incHistUsuCod);
                sql.Parameters.AddWithValue("@histNota", this.incHistNota);
                sql.Parameters.AddWithValue("@histHrs", this.incHistTiempo);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "historia");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
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

        private String DateTimeToDateSQL(DateTime dateTime)
        {
            String result = "";

            result += dateTime.Month + "/";
            result += dateTime.Day + "/";
            result += dateTime.Year;

            return result;
        }
    }
}
