using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class Proyecto_Persist
    {
        private int proCod;
        private string proNom;
        private string proDes;
        private string proEst;

        public int ProCod
        {
            get { return proCod; }
            set { proCod = value; }
        }

        public string ProNom
        {
            get { return proNom; }
            set { proNom = value; }
        }

        public string ProDes
        {
            get { return proDes; }
            set { proDes = value; }
        }

        public string ProEst
        {
            get { return proEst; }
            set { proEst = value; }
        }

        public Proyecto_Persist(string proNom, string proDes, string proEst)
        {
            this.proNom = proNom;
            this.proDes = proDes;
            this.proEst = proEst;
        }

        public Proyecto_Persist(int proCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM proyecto WHERE proCod = @proCod";
                sql.Parameters.AddWithValue("@proCod", proCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "proyecto");
                DataTable dt = ds.Tables["proyecto"];
                this.proCod = dt.Rows[0].Field<int>("proCod");
                //cargo los atributos del usuario
                this.proNom = dt.Rows[0].Field<string>("proNom");
                this.proDes = dt.Rows[0].Field<string>("proDes");
                this.proEst = dt.Rows[0].Field<string>("proEst");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void ProyectoCreate()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO proyecto (proNom, proDes, proEst) VALUES (@proNom, @proDes, @proEst)";
                sql.Parameters.AddWithValue("@proNom", this.proNom);
                sql.Parameters.AddWithValue("@proDes", this.proDes);
                sql.Parameters.AddWithValue("@proEst", this.proEst);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "proyecto");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void ProyectoUpdate(string proNom, string proDes, string proEst)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "UPDATE proyecto SET proNom = @proNom, proDes = @proDes, proEst = @proEst WHERE proCod = @proCod";
                sql.Parameters.AddWithValue("@proCod", this.proCod);
                sql.Parameters.AddWithValue("@proNom", proNom);
                sql.Parameters.AddWithValue("@proDes", proDes);
                sql.Parameters.AddWithValue("@proEst", proEst);
                SQLExecute sqlIns = new SQLExecute();
                sqlIns.Execute(sql, "proyecto");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //
        public void ProGrpAdd(string grpUsuCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "INSERT INTO proyectoGrupoUsuario (proCod, proGrpUsuCod) VALUES (@proCod, @proGrpUsuCod)";
                sql.Parameters.AddWithValue("@proCod", this.proCod);
                sql.Parameters.AddWithValue("@proGrpUsuCod", grpUsuCod);
                SQLExecute sqlInsSeg = new SQLExecute();
                sqlInsSeg.Execute(sql, "proyectoGrupoUsuario");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
