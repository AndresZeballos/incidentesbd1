using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class IncidenteHistoria_Logic
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

        public IncidenteHistoria_Logic(
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

        public IncidenteHistoria_Logic(int incHistCod)
        {
            try
            {
                IncidenteHistoria_Persist histPersist = new IncidenteHistoria_Persist(incHistCod);
                this.incHistCod = histPersist.IncHistCod;
                this.incHistIncCod = histPersist.IncHistIncCod;
                this.incHistEstIni = histPersist.IncHistEstIni;
                this.incHistEstFin = histPersist.IncHistEstFin;
                this.incHistFec = histPersist.IncHistFec;
                this.incHistAcc = histPersist.IncHistAcc;
                this.incHistUsuCod = histPersist.IncHistUsuCod;
                this.incHistNota = histPersist.IncHistNota;
                this.incHistTiempo = histPersist.IncHistTiempo;
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
                IncidenteHistoria_Persist histPersist = new IncidenteHistoria_Persist(
                                                                                    this.incHistIncCod,
                                                                                    this.incHistEstIni,
                                                                                    this.incHistEstFin,
                                                                                    this.incHistFec,
                                                                                    this.incHistAcc,
                                                                                    this.incHistUsuCod,
                                                                                    this.incHistNota,
                                                                                    this.incHistTiempo);
                histPersist.IncidenteHistoriaCreate();
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
                IncidenteHistoria_Persist histPersist = new IncidenteHistoria_Persist(this.incHistCod);
                histPersist.IncidenteHistoriaDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
