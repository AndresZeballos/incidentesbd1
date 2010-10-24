using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class View_Logic
    {


        public DataSet View_GeneralProjects()
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_GeneralProjects();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralGroups()
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_GeneralGroups();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralUsers()
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_GeneralUsers();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralIncidents(int proCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_GeneralIncidents(proCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GroupUsers(string grpUsuCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_GroupUsers(grpUsuCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_History(int ProCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_History(ProCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralRol()
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_GeneralRol();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public IList<string> View_GeneralState()
        {
            try
            {
                View_Persist vp = new View_Persist();
                DataSet ds = vp.View_GeneralState();

                DataTable dt = ds.Tables["estado"];
                IList<string> lista = new List<string>();
                foreach (DataRow drow in dt.Rows)
                {
                    lista.Add(drow.Field<string>("estCod"));
                }
                return lista;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralSecurity()
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_GeneralSecurity();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet Consult_GeneralCategory()
        {
            try
            {
                View_Persist vp = new View_Persist();

                return vp.View_GeneralCategory();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public IList<string> View_GeneralCategory()
        {
            try
            {
                View_Persist vp = new View_Persist();

                DataSet ds = vp.View_GeneralCategory();
                DataTable dt = ds.Tables["categoria"];
                IList<string> lista = new List<string>();
                foreach (DataRow drow in dt.Rows)
                {
                    lista.Add(drow.Field<string>("catCod"));
                }

                return lista;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet Consult_GeneralPriority()
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_GeneralPriority();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public IList<string> View_GeneralPriority()
        {
            try
            {
                View_Persist vp = new View_Persist();

                DataSet ds = vp.View_GeneralPriority();
                DataTable dt = ds.Tables["prioridad"];
                IList<string> lista = new List<string>();
                foreach (DataRow drow in dt.Rows)
                {
                    lista.Add(drow.Field<string>("priCod"));
                }

                return lista;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet Consult_GeneralSeverity()
        {
            try
            {
                View_Persist vp = new View_Persist();

                return vp.View_GeneralSeverity();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public IList<string> View_GeneralSeverity()
        {
            try
            {
                View_Persist vp = new View_Persist();

                DataSet ds = vp.View_GeneralSeverity();
                DataTable dt = ds.Tables["severidad"];
                IList<string> lista = new List<string>();
                foreach (DataRow drow in dt.Rows)
                {
                    lista.Add(drow.Field<string>("sevCod"));
                }

                return lista;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_UserRol(string usuCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_UserRol(usuCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_UserRol(int usuCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_Option_UserRol(usuCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_NextState(string estCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_Option_NextState(estCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_RolSecurity(string rolCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_RolSecurity(rolCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_RolSecurity(string rolCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_Option_RolSecurity(rolCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_GroupUser(string grpCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_Option_GroupUser(grpCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_ProjectGroup(int proCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_ProjectGroup(proCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_ProjectGroup(int proCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_Option_ProjectGroup(proCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet Consult_Incident(int incCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.Consult_Incident(incCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet Consult_HistoryNote(int histCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.Consult_HistoryNote(histCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //FALTO LA VISTA DE LA BUSQUEDA AVANZADA!!!!!!!!!!!!!!!!!!!!
        //TE PASO TODOS LOS PRAMETROS Q SE PUEDEN UTILIZAR EN LA BUSQUEDA Y M RETORNAS 
        //LA TABLA CONEL RESULTADO DE LA CONSULTA SEGÚN LOS PARAMETROS ? 
        //(tenes q chequear sin son null y eso, nose como es)

        public DataSet View_AdvancedSearch()
        {
            return null;
        }


        public DataSet View_IncidentSearch(int incProCod, string incEstCod, string incPriCod, string incCatCod, int incUsuAsig, string incSevCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_IncidentSearch(incProCod, incEstCod, incPriCod, incCatCod, incUsuAsig, incSevCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //También faltan las vistas de los filtros simples (“simples”je agarrate)


        public DataSet View_IncidentOrderBy_State(int incProCod, string incEstCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_IncidentOrderBy_State(incProCod, incEstCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_Priority(int incProCod, string incPriCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_IncidentOrderBy_Priority(incProCod, incPriCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_Category(int incProCod, string incCatCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_IncidentOrderBy_Category(incProCod, incCatCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_Severity(int incProCod, string incSevCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_IncidentOrderBy_Severity(incProCod, incSevCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_Date(int incProCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_IncidentOrderBy_Date(incProCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_LastestUpdate(int incProCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_IncidentOrderBy_LastestUpdate(incProCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }



        public DataSet View_IncidentOrderBy(int incProCod, string by)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.View_IncidentOrderBy(incProCod, by);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }





        

        public List<string> consult_projectOfUser(string usuCod)
        {
            try
            {
                List<string> result = new List<string>();

                View_Persist vp = new View_Persist();
                DataSet ds = vp.consult_projectOfUser(usuCod);
                DataTable dt = ds.Tables["ProjectByUser"];
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        int proCod = dt.Rows[i].Field<int>("proCod");
                        string proNom = dt.Rows[i].Field<string>("proNom");
                        result.Add(proCod + "- " + proNom);
                    }
                }


                return result;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet consult_2(string usuCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.consult_2(usuCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet consult_3(string usuCod)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.consult_3(usuCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet consult_4(string usuNom)
        {
            try
            {
                View_Persist vp = new View_Persist();
                return vp.consult_4(usuNom);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public List<string> userByProject(int proCod)
        {
            try
            {
                List<string> result = new List<string>();

                View_Persist vp = new View_Persist();
                DataSet ds = vp.userByProject(proCod);
                DataTable dt = ds.Tables["UserByProject"];
                if (dt.Rows.Count != 0)
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        result.Add(dt.Rows[i].Field<string>("usuCod"));
                    }
                }

                return result;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }


        public Estado_Logic EstadoInicial()
        {
            try
            {
                View_Persist vp = new View_Persist();
                DataSet ds = vp.EstadoInicial();
                DataTable dt = ds.Tables["estado"];
                string estCod = dt.Rows[0].Field<string>("estCod");
                Estado_Logic el = new Estado_Logic(estCod);
                return el;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public Estado_Logic EstadoFinal()
        {
            try
            {
                View_Persist vp = new View_Persist();
                DataSet ds = vp.EstadoFinal();
                DataTable dt = ds.Tables["estado"];
                string estCod = dt.Rows[0].Field<string>("estCod");
                Estado_Logic el = new Estado_Logic(estCod);
                return el;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
