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
        private string incUsuAsig;
        private string incDes;
        private string incRes;

        public int IncCod { get; set; }
        public int IncProCod { get; set; }
        public string IncCatCod { get; set; }
        public string IncSevCod { get; set; }
        public string IncPriCod { get; set; }
        public string IncEstCod { get; set; }
        public int IncEstHrs { get; set; }
        public DateTime IncFecIng { get; set; }
        public DateTime IncFecUltAct { get; set; }
        public DateTime IncFecFin { get; set; }
        public DateTime IncEstFecIni { get; set; }
        public DateTime IncEstFecFin { get; set; }
        public string IncUsuCod { get; set; }
        public string IncUsuAsig { get; set; }
        public string IncDes { get; set; }
        public string IncRes { get; set; }

        public Incidente_Persist(
                                int incCod,
                                int incProCod,
                                string incCatCod,
                                string incSevCod,
                                string incPriCod,
                                string incEstCod,
                                int incEstHrs,
                                DateTime incFecIng,
                                DateTime incFecUltAct,
                                DateTime incFecFin,
                                DateTime incEstFecIni,
                                DateTime incEstFecFin,
                                string incUsuCod,
                                string incUsuAsig,
                                string incDes,
                                string incRes
                                )
        {
            this.incCod = incCod;
            this.incProCod = incProCod;
            this.incCatCod = incCatCod;
            this.incSevCod = incSevCod;
            this.incPriCod = incPriCod;
            this.incEstCod = incEstCod;
            this.incEstHrs = incEstHrs;
            this.incFecIng = incFecIng;
            this.incFecUltAct = incFecUltAct;
            this.incFecFin = incFecFin;
            this.incEstFecIni = incEstFecIni;
            this.incEstFecFin = incEstFecFin;
            this.incUsuCod = incUsuCod;
            this.incUsuAsig = incUsuAsig;
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
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["incidente"];
                //cargo los atributos del incidente
                this.incCod = dt.Rows[0].Field<int>("incCod");
                this.incProCod = dt.Rows[0].Field<int>("incProCod");
                this.incCatCod = dt.Rows[0].Field<string>("incCatCod");
                this.incSevCod = dt.Rows[0].Field<string>("incSevCod");
                this.incPriCod = dt.Rows[0].Field<string>("incPriCod");
                this.incEstCod = dt.Rows[0].Field<string>("incEstCod");
                this.incEstHrs = dt.Rows[0].Field<int>("incSevCod"); ;
                this.incFecIng = dt.Rows[0].Field<DateTime>("incFecIng");
                this.incFecUltAct = dt.Rows[0].Field<DateTime>("incFecUltAct");
                this.incFecFin = dt.Rows[0].Field<DateTime>("incFecFin");
                this.incEstFecIni = dt.Rows[0].Field<DateTime>("incEstFecIni");
                this.incEstFecFin = dt.Rows[0].Field<DateTime>("incEstFecFin");
                this.incUsuCod = dt.Rows[0].Field<string>("incUsuCod");
                this.incUsuAsig = dt.Rows[0].Field<string>("incUsuAsig");
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
                sql.CommandText = "INSERT INTO incidente "+
                "(incCod,incProCod,incCatCod,incSevCod,incPriCod,incEstCod,incEstHrs,incFecIng,incFecUltAct,"+
                "incFecFin,incEstFecIni,incEstFecFin,incUsuCod,incUsuAsig,incDes,incRes) "+
                "VALUES "+
                "(@incCod,@incProCod,@incCatCod,@incSevCod,@incPriCod,@incEstCod,@incEstHrs,@incFecIng,@incFecUltAct,"+
                "@incFecFin,@incEstFecIni,@incEstFecFin,@incUsuCod,@incUsuAsig,@incDes,@incRes)";
                sql.Parameters.AddWithValue("@incCod", this.incCod);
                sql.Parameters.AddWithValue("@incProCod", this.incProCod);
                sql.Parameters.AddWithValue("@incCatCod", this.incCatCod);
                sql.Parameters.AddWithValue("@incSevCod", this.incSevCod);
                sql.Parameters.AddWithValue("@incPriCod", this.incPriCod);
                sql.Parameters.AddWithValue("@incEstCod", this.incEstCod);
                sql.Parameters.AddWithValue("@incEstHrs", this.incEstHrs);
                sql.Parameters.AddWithValue("@incFecIng", this.incFecIng);
                sql.Parameters.AddWithValue("@incFecUltAct", this.incFecUltAct);
                sql.Parameters.AddWithValue("@incFecFin", this.incFecFin);
                sql.Parameters.AddWithValue("@incEstFecIni", this.incEstFecIni);
                sql.Parameters.AddWithValue("@incEstFecFin", this.incEstFecFin);
                sql.Parameters.AddWithValue("@incUsuCod", this.incUsuCod);
                sql.Parameters.AddWithValue("@incUsuAsig", this.incUsuAsig);
                sql.Parameters.AddWithValue("@incDes", this.incDes);
                sql.Parameters.AddWithValue("@incRes", this.incRes);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
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
                sqlIns.Execute(sql);
                sql.Parameters.Clear();
                //elimino el incidente propiamente dicho
                sql.CommandText = "DELETE FROM	incidente WHERE incCod=@incCod";
                sql.Parameters.AddWithValue("@incCod", this.incCod);
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteUpdate(string nuevaincCatCod, string nuevaincSevCod, string nuevaincPriCod, string nuevaincEstCod, int nuevaincEstHrs, DateTime nuevaincFecIng, DateTime nuevaincFecUltAct, DateTime nuevaincFecFin, DateTime nuevaincEstFecIni, DateTime nuevaincEstFecFin, string nuevaincUsuCod, string nuevaincUsuAsig, string nuevaincDes, string nuevaincRes)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE INTO incidente SET " +
                "incCatCod=@incCatCod,incSevCod=@incSevCod,incPriCod=@incPriCod,"+
                "incEstCod=@incEstCod,incEstHrs=@incEstHrs,incFecIng=@incFecIng,incFecUltAct=@incFecUltAct," +
                "incFecFin=@incFecFin,incEstFecIni=@incEstFecIni,incEstFecFin=@incEstFecFin,incUsuCod=@incUsuCod,"+
                "incUsuAsig=@incUsuAsig,incDes=@incDes,incRes=@incRes) WHERE incCod=@incCod";
                sql.Parameters.AddWithValue("@incCod", this.incCod);
                sql.Parameters.AddWithValue("@incCatCod", this.incCatCod);
                sql.Parameters.AddWithValue("@incSevCod", this.incSevCod);
                sql.Parameters.AddWithValue("@incPriCod", this.incPriCod);
                sql.Parameters.AddWithValue("@incEstCod", this.incEstCod);
                sql.Parameters.AddWithValue("@incEstHrs", this.incEstHrs);
                sql.Parameters.AddWithValue("@incFecIng", this.incFecIng);
                sql.Parameters.AddWithValue("@incFecUltAct", this.incFecUltAct);
                sql.Parameters.AddWithValue("@incFecFin", this.incFecFin);
                sql.Parameters.AddWithValue("@incEstFecIni", this.incEstFecIni);
                sql.Parameters.AddWithValue("@incEstFecFin", this.incEstFecFin);
                sql.Parameters.AddWithValue("@incUsuCod", this.incUsuCod);
                sql.Parameters.AddWithValue("@incUsuAsig", this.incUsuAsig);
                sql.Parameters.AddWithValue("@incDes", this.incDes);
                sql.Parameters.AddWithValue("@incRes", this.incRes);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteAsign(string nuevaincUsuAsig)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE INTO incidente SET incUsuAsig=@incUsuAsig WHERE incCod=@incCod";
                sql.Parameters.AddWithValue("@incCod", this.incCod);
                sql.Parameters.AddWithValue("@incUsuAsig", this.incUsuAsig);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
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
                DataSet ds = sqlIns.Execute(sql);
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
    }
}
