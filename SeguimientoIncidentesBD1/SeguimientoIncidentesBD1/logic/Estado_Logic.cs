using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Estado_Logic
    {
        private string estCod;
        //falta incluir los siguientes atributos en el código
        private IList<string> estSigEstCod = new List<string>();
        private bool estIni;
        private bool estFin;
        private bool estEst;

        public string EstCod
        {
            get { return estCod; }
            set { estCod = value; }
        }

        public IList<string> EstSigEstCod
        {
            get { return estSigEstCod; }
            set { estSigEstCod = value; }
        }

        public bool EstIni
        {
            get { return estIni; }
            set { estIni = value; }
        }

        public bool EstFin
        {
            get { return estFin; }
            set { estFin = value; }
        }

        public bool EstEst
        {
            get { return estEst; }
            set { estEst = value; }
        }


        public Estado_Logic(string estCod, bool estIni, bool estFin, bool estEst)
        {
            this.estCod = estCod;
            this.estIni = estIni;
            this.estFin = estFin;
            this.estEst = estEst;
        }

        public Estado_Logic(string estCod)
        {
            Estado_Persist est = new Estado_Persist(estCod);
            this.estSigEstCod = est.EstSigEstCod;
            this.estIni = est.EstIni;
            this.estFin = est.EstFin;
            this.estEst = est.EstEst;
        }

        public void EstadoPersist()
        {
            try
            {
                Estado_Persist est = new Estado_Persist(this.estCod, this.estIni, this.estFin, this.estEst);
                est.EstadoCreate();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
        
        public void EstadoDelete()
        {
            try
            {
                Estado_Persist est = new Estado_Persist(this.estCod);
                est.EstadoDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void EstadoSigAdd(string estCod)
        {
            try
            {
                //actualizo la lista de seguridades
                this.estSigEstCod.Add(estCod);
                Estado_Persist estPersist = new Estado_Persist(this.estCod);
                estPersist.EstadoSigAdd(estCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void EstadoSigAddAll(IList<string> estCod)
        {
            try
            {
                //actualizo la lista de seguridades
                this.estSigEstCod = estCod;
                Estado_Persist estPersist = new Estado_Persist(this.estCod);
                estPersist.EstadoSigAddAll(estCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
