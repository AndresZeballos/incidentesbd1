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

        public int IncCod
        {
            get { return incCod; }
            set { incCod = value; }
        }
        public int IncProCod
        {
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
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
            catch (Exception e)
            {
                throw e;
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
                this.incUsuAsi = nuevaincUsuAsig;
                this.incDes = nuevaincDes;
                this.incRes = nuevaincRes;
                incPersist.IncidenteUpdate(
                                            nuevaincCatCod,
                                            nuevaincSevCod,
                                            nuevaincPriCod,
                                            nuevaincEstCod,
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


        //Este metodo cierra el incidente grabado la fecha de fin
        public void FinalizarIncidente()
        {
            try
            {
                Incidente_Persist incPersist = new Incidente_Persist(this.incCod);
                incPersist.FinalizarIncidente();
                this.incFecFin = incPersist.IncFecFin;
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
