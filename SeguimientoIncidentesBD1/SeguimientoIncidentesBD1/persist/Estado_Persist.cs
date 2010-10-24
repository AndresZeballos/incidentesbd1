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

        public Estado_Persist(string estCod, bool estIni, bool estFin, bool estEst)
        {
            this.estCod = estCod;
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
                DataSet ds = sqlIns.Execute(sql, "estado");
                DataTable dt = ds.Tables["estado"];
                this.estCod = dt.Rows[0].Field<string>("estCod");
                //cargo la los atributos del estado
                
                byte estIniByte = dt.Rows[0].Field<byte>("estIni");
                if (estIniByte == 0)
                    this.estIni = false;
                else
                    this.estIni = true;
                byte estFinByte = dt.Rows[0].Field<byte>("estFin");
                if (estFinByte == 0)
                    this.estFin = false;
                else
                    this.estFin = true;
                byte estEstByte = dt.Rows[0].Field<byte>("estEst");
                if (estEstByte == 0)
                    this.estEst = false;
                else
                    this.estEst = true;

                sql.Parameters.Clear();
                //hago la consulta sobre la tabla estadoSeguridad
                sql.CommandText = "SELECT * FROM estadoSiguiente WHERE estCod = @estCod";
                sql.Parameters.AddWithValue("@estCod", estCod);
                SQLExecute sqlInsestadoSeg = new SQLExecute();
                DataSet dsestadoSig = sqlIns.Execute(sql, "estadoSiguiente");
                DataTable dtestadoSig = dsestadoSig.Tables["estadoSiguiente"];
                foreach (DataRow drow in dtestadoSig.Rows)
                {
                    this.estSigEstCod.Add(drow.Field<string>("estSigEstCod"));
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void EstadoCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO estado (estCod, estIni, estFin, estEst) VALUES (@estCod, @estIni, @estFin, @estEst)";
                
                sql.Parameters.AddWithValue("@estCod", this.estCod);

                if (this.estIni)
                    sql.Parameters.AddWithValue("@estIni", "0x1");
                else
                    sql.Parameters.AddWithValue("@estIni", "0x0");
                if (this.estFin)
                    sql.Parameters.AddWithValue("@estFin", "0x1");
                else
                    sql.Parameters.AddWithValue("@estFin", "0x0");
                if (this.estEst)
                    sql.Parameters.AddWithValue("@estEst", "0x1");
                else
                    sql.Parameters.AddWithValue("@estEst", "0x0");
 
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "estado");                
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
                SqlCommand sql = new SqlCommand();
                //elimino primero las asociaciones del estado con sus siguientes
                sql.CommandText = "DELETE FROM estadoSiguiente WHERE estCod=@estCod";
                sql.Parameters.AddWithValue("@estCod", this.estCod);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "estadoSiguiente");
                sql.Parameters.Clear();
                //elimino el estado propiamente dicho
                sql.CommandText = "DELETE FROM	estado WHERE estCod=@estCod";
                sql.Parameters.AddWithValue("@estCod", this.estCod);
                SQLExecute sqlIns2 = new SQLExecute();
                sqlIns2.Execute(sql, "estado");
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
                sqlInsSeg.Execute(sql, "estadoSiguiente");
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
                this.estSigEstCod = estCod;
                SqlCommand sql = new SqlCommand();
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
                    sqlInsSeg.Execute(sql, "estadoSiguiente");
                }
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
