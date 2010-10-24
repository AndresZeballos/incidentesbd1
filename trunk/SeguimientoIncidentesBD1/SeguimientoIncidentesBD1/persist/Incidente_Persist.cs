using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class Incidente_Persist
    {
        private int incCod;
        private int incProCod;
        private string incCatCod;
        private string incSevCod;
        private string incPriCod;
        private string incEstCod;
        private int incEstHrs;
        private DateTime incFecIng;
        private DateTime incFecUltAct;
        private DateTime incFecFin;
        private DateTime incEstFecIni;
        private DateTime incEstFecFin;
        private string incUsuCod;
        private string incUsuAsi;
        private string incDes;
        private string incRes;

        public int IncCod {
            get { return incCod; }
            set { incCod = value; }
        }
        public int IncProCod {
            get { return incProCod; }
            set { incProCod = value; }
        }
        public string IncCatCod
        {
            get { return incCatCod; }
            set { incCatCod = value; }
        }
        public string IncSevCod
        {
            get { return incSevCod; }
            set { incSevCod = value; }
        }
        public string IncPriCod
        {
            get { return incPriCod; }
            set { incPriCod = value; }
        }
        public string IncEstCod
        {
            get { return incEstCod; }
            set { incEstCod = value; }
        }
        public int IncEstHrs
        {
            get { return incEstHrs; }
            set { incEstHrs = value; }
        }
        public DateTime IncFecIng
        {
            get { return incFecIng; }
            set { incFecIng = value; }
        }
        public DateTime IncFecUltAct
        {
            get { return incFecUltAct; }
            set { incFecUltAct = value; }
        }
        public DateTime IncFecFin
        {
            get { return incFecFin; }
            set { incFecFin = value; }
        }
        public DateTime IncEstFecIni
        {
            get { return incEstFecIni; }
            set { incEstFecIni = value; }
        }
        public DateTime IncEstFecFin
        {
            get { return incEstFecFin; }
            set { incEstFecFin = value; }
        }
        public string IncUsuCod
        {
            get { return incUsuCod; }
            set { incUsuCod = value; }
        }
        public string IncUsuAsi
        {
            get { return incUsuAsi; }
            set { incUsuAsi = value; }
        }
        public string IncDes
        {
            get { return incDes; }
            set { incDes = value; }
        }
        public string IncRes
        {
            get { return incRes; }
            set { incRes = value; }
        }

        public Incidente_Persist(
                                int incProCod,
                                string incCatCod,
                                string incSevCod,
                                string incPriCod,
                                string incEstCod,

                                DateTime incFecIng,
                                DateTime incFecUltAct,

                                string incUsuCod,
                                string incUsuAsi,
                                string incDes,
                                string incRes
                                )
        {
            this.incProCod = incProCod;
            this.incCatCod = incCatCod;
            this.incSevCod = incSevCod;
            this.incPriCod = incPriCod;
            this.incEstCod = incEstCod;

            this.incFecIng = incFecIng;
            this.incFecUltAct = incFecUltAct;

            this.incUsuCod = incUsuCod;
            this.incUsuAsi = incUsuAsi;
            this.incDes = incDes;
            this.incRes = incRes;
        }


        // Constructor cuando no se asigna usuario
        public Incidente_Persist(
                                int incProCod,
                                string incCatCod,
                                string incSevCod,
                                string incPriCod,
                                string incEstCod,

                                DateTime incFecIng,
                                DateTime incFecUltAct,

                                string incUsuCod,
                                string incDes,
                                string incRes
                                )
        {
            this.incProCod = incProCod;
            this.incCatCod = incCatCod;
            this.incSevCod = incSevCod;
            this.incPriCod = incPriCod;
            this.incEstCod = incEstCod;

            this.incFecIng = incFecIng;
            this.incFecUltAct = incFecUltAct;

            this.incUsuCod = incUsuCod;
            this.incDes = incDes;
            this.incRes = incRes;
        }

        public Incidente_Persist(int incCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM incidente WHERE incCod = @incCod";
                sql.Parameters.AddWithValue("@incCod", incCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                DataTable dt = ds.Tables["incidente"];
                //cargo los atributos del incidente
                this.incCod = dt.Rows[0].Field<int>("incCod");
                this.incProCod = dt.Rows[0].Field<int>("incProCod");
                this.incCatCod = dt.Rows[0].Field<string>("incCatCod");
                this.incSevCod = dt.Rows[0].Field<string>("incSevCod");
                this.incPriCod = dt.Rows[0].Field<string>("incPriCod");
                this.incEstCod = dt.Rows[0].Field<string>("incEstCod");

                this.incEstHrs = dt.Rows[0].Field<int>("incEstHrs");
                
                this.incFecIng = dt.Rows[0].Field<DateTime>("incFecIng");
                this.incFecUltAct = dt.Rows[0].Field<DateTime>("incFecUltAct");
                this.incFecFin = dt.Rows[0].Field<DateTime>("incFecFin");
                this.incEstFecIni = dt.Rows[0].Field<DateTime>("incEstFecIni");
                this.incEstFecFin = dt.Rows[0].Field<DateTime>("incEstFecFin");

                this.incUsuCod = dt.Rows[0].Field<string>("incUsuCod");
                this.incUsuAsi = dt.Rows[0].Field<string>("incUsuAsi");
                this.incDes = dt.Rows[0].Field<string>("incDes");
                this.incRes = dt.Rows[0].Field<string>("incRes");
                
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();

                string text = "INSERT INTO incidente " +
                        "(incProCod, incCatCod, incSevCod, incPriCod, incEstCod, incEstHrs, incFecIng, incFecUltAct, " +
                        "incFecFin, incEstFecIni, incEstFecFin, incUsuCod, ";

                if (this.incUsuAsi != null)
                    text += "incUsuAsi, ";

                text += "incDes, incRes) " +
                        "VALUES " +
                        "(@incProCod, @incCatCod, @incSevCod, @incPriCod, @incEstCod, @incEstHrs, @incFecIng, @incFecUltAct, " +
                        "@incFecFin, @incEstFecIni, @incEstFecFin, @incUsuCod,";

                if (this.incUsuAsi != null)
                    text += "@incUsuAsi, ";

                text += "@incDes, @incRes)";

                sql.CommandText = text;
          

                sql.Parameters.AddWithValue("@incProCod", this.incProCod);
                sql.Parameters.AddWithValue("@incCatCod", this.incCatCod);
                sql.Parameters.AddWithValue("@incSevCod", this.incSevCod);
                sql.Parameters.AddWithValue("@incPriCod", this.incPriCod);
                sql.Parameters.AddWithValue("@incEstCod", this.incEstCod);
                sql.Parameters.AddWithValue("@incEstHrs", this.incEstHrs);

                sql.Parameters.AddWithValue("@incFecIng", DateTimeToDateSQL(this.incFecIng));
                sql.Parameters.AddWithValue("@incFecUltAct", DateTimeToDateSQL(this.incFecUltAct));
                sql.Parameters.AddWithValue("@incFecFin", DateTimeToDateSQL(this.incFecFin));
                sql.Parameters.AddWithValue("@incEstFecIni", DateTimeToDateSQL(this.incEstFecIni));
                sql.Parameters.AddWithValue("@incEstFecFin", DateTimeToDateSQL(this.incEstFecFin));
                
                sql.Parameters.AddWithValue("@incUsuCod", this.incUsuCod);

                if (this.incUsuAsi != null)
                    sql.Parameters.AddWithValue("@incUsuAsi", this.incUsuAsi);

                sql.Parameters.AddWithValue("@incDes", this.incDes);
                sql.Parameters.AddWithValue("@incRes", this.incRes);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "incidente");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                //elimino primero las asociaciones del incidente con historia
                sql.CommandText = "DELETE FROM historia WHERE histIncCod=@histIncCod";
                sql.Parameters.AddWithValue("@histIncCod", this.incCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "historia");
                sql.Parameters.Clear();
                //elimino el incidente propiamente dicho
                sql.CommandText = "DELETE FROM	incidente WHERE incCod=@incCod";
                sql.Parameters.AddWithValue("@incCod", this.incCod);
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql, "incidente");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteUpdate(
                                    string nuevaincCatCod, 
                                    string nuevaincSevCod, 
                                    string nuevaincPriCod, 
                                    string nuevaincEstCod, 
                                    int nuevaincEstHrs, 
                                    DateTime nuevaincFecIng, 
                                    DateTime nuevaincFecUltAct, 
                                    DateTime nuevaincFecFin, 
                                    DateTime nuevaincEstFecIni, 
                                    DateTime nuevaincEstFecFin, 
                                    string nuevaincUsuCod, 
                                    string nuevaincUsuAsi, 
                                    string nuevaincDes, 
                                    string nuevaincRes
                                    )
        {
            try
            {
                //actualizo con los nuevos datos
                this.incCatCod = nuevaincCatCod;
                this.incSevCod = nuevaincSevCod;
                this.incPriCod = nuevaincPriCod;
                this.incEstCod = nuevaincEstCod;
                this.incEstHrs = nuevaincEstHrs;
                this.incFecIng = nuevaincFecIng;
                this.incFecUltAct = nuevaincFecUltAct;
                this.incFecFin = nuevaincFecFin;
                this.incEstFecIni = nuevaincEstFecIni;
                this.incEstFecFin = nuevaincEstFecFin;
                this.incUsuCod = nuevaincUsuCod;
                this.incUsuAsi = nuevaincUsuAsi;
                this.incDes = nuevaincDes;
                this.incRes = nuevaincRes;
                SqlCommand sql = new SqlCommand();

                string text = "UPDATE INTO incidente SET " +
                "incCatCod=@incCatCod, incSevCod=@incSevCod, incPriCod=@incPriCod, " +
                "incEstCod=@incEstCod, incEstHrs=@incEstHrs, incFecIng=@incFecIng, incFecUltAct=@incFecUltAct, " +
                "incFecFin=@incFecFin, incEstFecIni=@incEstFecIni, incEstFecFin=@incEstFecFin, incUsuCod=@incUsuCod, ";

                if (nuevaincUsuAsi != null)
                    text += "incUsuAsi=@incUsuAsi, ";

                text += "incDes=@incDes, incRes=@incRes) WHERE incCod=@incCod";

                sql.CommandText = text;
                sql.Parameters.AddWithValue("@incCod", this.incCod);
                sql.Parameters.AddWithValue("@incCatCod", nuevaincCatCod);
                sql.Parameters.AddWithValue("@incSevCod", nuevaincSevCod);
                sql.Parameters.AddWithValue("@incPriCod", nuevaincPriCod);
                sql.Parameters.AddWithValue("@incEstCod", nuevaincEstCod);
                sql.Parameters.AddWithValue("@incEstHrs", nuevaincEstHrs);

                sql.Parameters.AddWithValue("@incFecIng", DateTimeToDateSQL(nuevaincFecIng));
                sql.Parameters.AddWithValue("@incFecUltAct", DateTimeToDateSQL(nuevaincFecUltAct));
                sql.Parameters.AddWithValue("@incFecFin", DateTimeToDateSQL(nuevaincFecFin));
                sql.Parameters.AddWithValue("@incEstFecIni", DateTimeToDateSQL(nuevaincEstFecIni));
                sql.Parameters.AddWithValue("@incEstFecFin", DateTimeToDateSQL(nuevaincEstFecFin));

                sql.Parameters.AddWithValue("@incUsuCod", nuevaincUsuCod);

                if (nuevaincUsuAsi != null)
                    sql.Parameters.AddWithValue("@incUsuAsi", nuevaincUsuAsi);

                sql.Parameters.AddWithValue("@incDes", nuevaincDes);
                sql.Parameters.AddWithValue("@incRes", nuevaincRes);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "incidente");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteAsign(string nuevaincUsuAsi)
        {
            try
            {
                this.incUsuAsi = nuevaincUsuAsi;
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE INTO incidente SET incUsuAsi=@incUsuAsi WHERE incCod=@incCod";
                sql.Parameters.AddWithValue("@incCod", this.incCod);
                sql.Parameters.AddWithValue("@incUsuAsi", nuevaincUsuAsi);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "incidente");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public IList<int> ObtenerHistoriaIncidente()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM historia WHERE histIncCod = @histIncCod";
                sql.Parameters.AddWithValue("@histIncCod", this.incCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "historia");
                DataTable dt = ds.Tables["historia"];
                IList<int> lista = new List<int>();
                //cargo la lista de eventos de la historia del incidente
                foreach(DataRow dr in dt.Rows)
                {
                    lista.Add(dr.Field<int>("histCod"));
                }
                return lista;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void FinalizarIncidente()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE INTO incidente SET incFecFin=@incFecFin WHERE incCod=@incCod";

                sql.Parameters.AddWithValue("@incFecFin", DateTimeToDateSQL(DateTime.Today));
                
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "incidente");
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

        public void EstimarIncidente(int incEstHrs, DateTime incEstFecIni, DateTime incEstFecFin)
        {
            try
            {
                this.incEstHrs = incEstHrs;
                this.incEstFecIni = incEstFecIni;
                this.incEstFecFin = incEstFecFin;
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE INTO incidente SET incEstHrs=@incEstHrs, incEstFecIni=@incEstFecIni, " +
                    "incEstFecFin=@incEstFecFin WHERE incCod=@incCod";
                sql.Parameters.AddWithValue("@incCod", this.incCod);
                sql.Parameters.AddWithValue("@incEstHrs", incEstHrs);
                sql.Parameters.AddWithValue("@incEstFecIni", DateTimeToDateSQL(incEstFecIni));
                sql.Parameters.AddWithValue("@incEstFecFin", DateTimeToDateSQL(incEstFecFin));
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "incidente");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
