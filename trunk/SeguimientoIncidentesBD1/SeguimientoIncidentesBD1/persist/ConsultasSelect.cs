using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class ConsultasSelect
    {
        private Conexion cnx;
        
        public ConsultasSelect(Conexion cnx)
        {
            this.cnx = cnx;
        }
        
        public DataSet PersonasTodas()
        {
            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter();
            
            SqlCommand cmd = new SqlCommand("", cnx.Connection);
            cmd.CommandText = "Select top 1 nombre from personas";
            SqlDataReader dr;
            cnx.Connection.Open();
            dr = cmd.ExecuteReader();
            // Al hacer while(dr.read()) el programa se para en la siguiente fila de la consulta
            // y si no es vacia devuelve true. Sirve para recorrer las filas una a una y procesar. 
            while (dr.Read())
            {
                System.Windows.Forms.MessageBox.Show(dr[0].ToString());
            }
            cnx.Connection.Close();

            //Otro ejemplo, para cargar el dataset
            cmd.CommandText = "Select * from personas";
            da.SelectCommand = cmd;
            // El data adapter llena el DataSet con la consulta que tiene.
            da.Fill(ds);
            return ds;
        }

        public DataSet ConsultaGeneral(String sqlText)
        {
            try
            {
                DataSet ds = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();

                SqlCommand cmd = new SqlCommand(sqlText, cnx.Connection);
                da.SelectCommand = cmd;
                da.Fill(ds);
                return ds;
            }
            catch (SqlException sqle) {
                Console.WriteLine(sqle.ToString());
                return null;
            }
        }
    }
}
