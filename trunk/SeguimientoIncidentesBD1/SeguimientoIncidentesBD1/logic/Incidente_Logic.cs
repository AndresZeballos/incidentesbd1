using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Incidente_Logic
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
        public string IncUsuAsi { get; set; }
        public string IncDes { get; set; }
        public string IncRes { get; set; }

        public Incidente_Logic(
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

        // Constructor cuando no se asigna un usuario
        public Incidente_Logic(
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


        //constructor que dado un código de incidente carga sus atributos
        public Incidente_Logic(int incCod)
        {
            try
            {
                Incidente_Persist incPersist = new Incidente_Persist(incCod);
                this.incCod = incPersist.IncCod;
                this.incProCod = incPersist.IncProCod;
                this.incCatCod = incPersist.IncCatCod;
                this.incSevCod = incPersist.IncSevCod;
                this.incPriCod = incPersist.IncPriCod;
                this.incEstCod = incPersist.IncEstCod;
                this.incEstHrs = incPersist.IncEstHrs;
                this.incFecIng = incPersist.IncFecIng;
                this.incFecUltAct = incPersist.IncFecUltAct;
                this.incFecFin = incPersist.IncFecFin;
                this.incEstFecIni = incPersist.IncEstFecIni;
                this.incEstFecFin = incPersist.IncEstFecFin;
                this.incUsuCod = incPersist.IncUsuCod;
                this.incUsuAsi = incPersist.IncUsuAsi;
                this.incDes = incPersist.IncDes;
                this.incRes = incPersist.IncRes;
            }
            catch(SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void IncidenteCreate()
        {
            try
            {
                Incidente_Persist incPersist;
                if (this.incUsuAsi != null)
                {
                     incPersist= new Incidente_Persist(
                                                                        this.incProCod,
                                                                        this.incCatCod,
                                                                        this.incSevCod,
                                                                        this.incPriCod,
                                                                        this.incEstCod,
                                                                        this.incFecIng,
                                                                        this.incFecUltAct,
                                                                        this.incUsuCod,
                                                                        this.incUsuAsi,
                                                                        this.incDes,
                                                                        this.incRes);
                }
                else
                {
                    incPersist = new Incidente_Persist(
                                                                        this.incProCod,
                                                                        this.incCatCod,
                                                                        this.incSevCod,
                                                                        this.incPriCod,
                                                                        this.incEstCod,
                                                                        this.incFecIng,
                                                                        this.incFecUltAct,
                                                                        this.incUsuCod,
                                                                        this.incDes,
                                                                        this.incRes);
                }
                incPersist.IncidenteCreate();
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
                Incidente_Persist incPersist = new Incidente_Persist(this.incCod);
                incPersist.IncidenteDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //actualiza los datos de un incidente
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
                                    string nuevaincUsuAsig,
                                    string nuevaincDes,
                                    string nuevaincRes)
        {
            try
            {
                Incidente_Persist incPersist = new Incidente_Persist(this.incCod);
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
                this.incUsuAsi = nuevaincUsuAsig;
                this.incDes = nuevaincDes;
                this.incRes = nuevaincRes;
                incPersist.IncidenteUpdate(
                                            nuevaincCatCod,
                                            nuevaincSevCod,
                                            nuevaincPriCod,
                                            nuevaincEstCod,
                                            nuevaincEstHrs,
                                            nuevaincFecIng,
                                            nuevaincFecUltAct,
                                            nuevaincFecFin,
                                            nuevaincEstFecIni,
                                            nuevaincEstFecFin,
                                            nuevaincUsuCod,
                                            nuevaincUsuAsig,
                                            nuevaincDes,
                                            nuevaincRes);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //asigna un incidente a un usuario
        public void IncidenteAsign(string nuevaincUsuAsig)
        {
            try
            {
                this.incUsuAsi = nuevaincUsuAsig;
                Incidente_Persist incPersist = new Incidente_Persist(this.incCod);
                incPersist.IncidenteAsign(nuevaincUsuAsig);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //devuelve toda la historia de un incidente, dentro de esta lista por ejemplo se puede buscar una nota en particular
        public IList<IncidenteHistoria_Logic> ObtenerHistoriaIncidente()
        {
            try
            {
                Incidente_Persist incPersist = new Incidente_Persist(this.incCod);
                IList<int> listaHistoria = incPersist.ObtenerHistoriaIncidente();
                IList<IncidenteHistoria_Logic> lHistRes = new List<IncidenteHistoria_Logic>();
                //para codigo de historia, cargo la historia en la lista de historias
                foreach (int hist in listaHistoria)
                {
                    IncidenteHistoria_Logic incHist = new IncidenteHistoria_Logic(hist);
                    lHistRes.Add(incHist);
                }
                return lHistRes;
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
                Incidente_Persist incPersist = new Incidente_Persist(this.incCod);
                //incPersist.IncidenteUpdate(
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void EstimarIncidente(int incEstHrs, DateTime incEstFecIni, DateTime incEstFecFin)
        {
            try
            {
                this.incEstHrs = incEstHrs;
                this.incEstFecIni = incEstFecIni;
                this.incEstFecFin = incEstFecFin;
                Incidente_Persist incPersist = new Incidente_Persist(this.incCod);
                incPersist.EstimarIncidente(this.incEstHrs, this.incEstFecIni, this.incEstFecFin);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

    }
}
