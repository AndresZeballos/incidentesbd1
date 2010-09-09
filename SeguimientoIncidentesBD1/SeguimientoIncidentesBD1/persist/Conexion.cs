using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using System.Xml;
using System.IO;

namespace SeguimientoIncidentesBD1.persist
{
    class Conexion
    {
        XmlDocument doc;
        XmlReader reader;
        private SqlConnection cnx;

        public Conexion()
        {
            SqlConnectionStringBuilder cnxBuilder = new SqlConnectionStringBuilder();
            DatosConexion();
            cnxBuilder.DataSource = GetParametro("DataSource");
            cnxBuilder.Password = GetParametro("Password");
            cnxBuilder.UserID = GetParametro("UserID");
            cnxBuilder.InitialCatalog = GetParametro("InitialCatalog");
            this.cnx = new SqlConnection(cnxBuilder.ConnectionString);
        }
        
        public SqlConnection Connection
        {
            get { return this.cnx; }
        }
        
        private void DatosConexion()
        {
            doc = new XmlDocument();
            string path = Path.Combine(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase), "conexion.xml");
            reader = XmlReader.Create(path);
            doc.Load(reader);
        }
        
        public string GetParametro(string parametro)
        {
            String valor = "";
            XmlNode nodo = doc.SelectSingleNode("/Conexion/Parametros");
            valor = nodo[parametro].Attributes["valor"].Value;
            valor.Trim();
            return valor;
        }
    }
}
