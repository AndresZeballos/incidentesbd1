using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    class Estado_Persist
    {
        private string estCod;
        //falta incluir los siguientes atributos en el código
        private IList<string> estSigEstCod;
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

        public Estado_Persist(string estCod, IList<string> estSigEstCod, bool estIni, bool estFin, bool estEst)
        {
            this.estCod = estCod;
            this.estSigEstCod = estSigEstCod;
            this.estIni = estIni;
            this.estFin = estFin;
            this.estEst = estEst;
        }

        //dado un código de estado, obtiene los demás atributos del mismo
        public Estado_Persist(string estCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM estado WHERE estCod = @estCod";
                sql.Parameters.AddWithValue("@estCod", estCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql);
                DataTable dt = ds.Tables["estado"];
                this.estCod = dt.Rows[0].Field<string>("estCod");
                //cargo la los atributos del estado
                this.estIni = dt.Rows[0].Field<bool>("estIni");
                this.estFin = dt.Rows[0].Field<bool>("estFin");
                this.estEst = dt.Rows[0].Field<bool>("estEst");
                sql.Parameters.Clear();
                //hago la consulta sobre la tabla estadoSeguridad
                sql.CommandText = "SELECT * FROM estadoSiguiente WHERE estCod = @estCod";
                sql.Parameters.AddWithValue("@estCod", this.estCod);
                SQLExecute sqlInsestadoSeg = new SQLExecute();
                DataSet dsestadoSig = sqlIns.Execute(sql);
                DataTable dtestadoSig = dsestadoSig.Tables["estadoSiguiente"];
                int i = 0;
                foreach (DataRow drow in dtestadoSig.Rows)
                {
                    this.estSigEstCod[i] = drow.Field<string>("estSigEstCod");
                    i++;
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        internal void EstadoCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO estado (estCod, estIni, estFin, estEst) VALUES (@estCod, @estIni, @estFin, @estEst)";
                sql.Parameters.AddWithValue("@estCod", this.estCod);
                sql.Parameters.AddWithValue("@estIni", this.estIni);
                sql.Parameters.AddWithValue("@estFin", this.estFin);
                sql.Parameters.AddWithValue("@estEst", this.estEst);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
                sql.Parameters.Clear();
                //agrego los siguientes estados del estado
                sql.CommandText = "INSERT INTO estadoSiguiente (estCod, estSigEstCod) VALUES (@estCod, @estSigEstCod)";
                //la base de datos debería chequear que el id exista en la tabla de estados
                sql.Parameters.AddWithValue("@estCod", "");
                sql.Parameters.AddWithValue("@estSigEstCod", "");
                sql.Parameters[0].Value = this.estCod;
                foreach (string estSig in this.estSigEstCod)
                {
                    sql.Parameters[1].Value = estSig;
                    SQLExecute sqlInsSeg = new SQLExecute();
                    sqlInsSeg.Execute(sql);
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        internal void EstadoDelete()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                //elimino primero las asociaciones del estado con sus siguientes
                sql.CommandText = "DELETE FROM estadoSiguiente WHERE estCod=@estCod";
                sql.Parameters.AddWithValue("@estCod", this.estCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql);
                sql.Parameters.Clear();
                //elimino el estado propiamente dicho
                sql.CommandText = "DELETE FROM	estado WHERE estCod=@estCod";
                sql.Parameters.AddWithValue("@estCod", this.estCod);
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql);
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
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO estadoSiguiente (estCod, estSigEstCod) VALUES (@estCod, @estSigEstCod)";
                //la base de datos debería controlar que el id exista en la tabla de seguridades
                sql.Parameters.AddWithValue("@estCod", this.estCod);
                sql.Parameters.AddWithValue("@estSigEstCod", estCod);
                SQLExecute sqlInsSeg = new SQLExecute();
                sqlInsSeg.Execute(sql);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
