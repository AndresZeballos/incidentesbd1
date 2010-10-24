﻿using System;
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
            View_Persist vp = new View_Persist();
            return vp.View_GeneralProjects();
        }

        public DataSet View_GeneralGroups()
        {
            View_Persist vp = new View_Persist();
            return vp.View_GeneralGroups();
        }

        public DataSet View_GeneralUsers()
        {
            View_Persist vp = new View_Persist();
            return vp.View_GeneralUsers();
        }

        public DataSet View_GeneralIncidents(int proCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_GeneralIncidents(proCod);
        }

        public DataSet View_GroupUsers(string grpUsuCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_GroupUsers(grpUsuCod);
        }

        public DataSet View_History(int ProCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_History(ProCod);
        }

        public DataSet View_GeneralRol()
        {
            View_Persist vp = new View_Persist();
            return vp.View_GeneralRol();
        }

        public IList<string> View_GeneralState()
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

        public DataSet View_GeneralSecurity()
        {
            View_Persist vp = new View_Persist();
            return vp.View_GeneralSecurity();
        }

        public IList<string> View_GeneralCategory()
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

        public IList<string> View_GeneralPriority()
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

        public IList<string> View_GeneralSeverity()
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

        public DataSet View_UserRol(int usuCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_UserRol(usuCod);
        }

        public DataSet View_Option_UserRol(int usuCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_Option_UserRol(usuCod);
        }

        public DataSet View_RolSecurity(string rolCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_RolSecurity(rolCod);
        }

        public DataSet View_Option_RolSecurity(string rolCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_Option_RolSecurity(rolCod);
        }

        public DataSet View_Option_GroupUser(string grpCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_Option_GroupUser(grpCod);
        }

        public DataSet View_ProjectGroup(int proCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_ProjectGroup(proCod);
        }

        public DataSet View_Option_ProjectGroup(int proCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_Option_ProjectGroup(proCod);
        }

        public DataSet Consult_Incident(int incCod)
        {
            View_Persist vp = new View_Persist();
            return vp.Consult_Incident(incCod);
        }

        public DataSet Consult_HistoryNote(int histCod)
        {
            View_Persist vp = new View_Persist();
            return vp.Consult_HistoryNote(histCod);
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
            View_Persist vp = new View_Persist();
            return vp.View_IncidentSearch(incProCod, incEstCod, incPriCod, incCatCod, incUsuAsig, incSevCod);
        }

        //También faltan las vistas de los filtros simples (“simples”je agarrate)


        public DataSet View_IncidentOrderBy_State(int incProCod, string incEstCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_IncidentOrderBy_State(incProCod, incEstCod);
        }

        public DataSet View_IncidentOrderBy_Priority(int incProCod, string incPriCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_IncidentOrderBy_Priority(incProCod, incPriCod);
        }

        public DataSet View_IncidentOrderBy_Category(int incProCod, string incCatCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_IncidentOrderBy_Category(incProCod, incCatCod);
        }

        public DataSet View_IncidentOrderBy_Severity(int incProCod, string incSevCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_IncidentOrderBy_Severity(incProCod, incSevCod);
        }

        public DataSet View_IncidentOrderBy_Date(int incProCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_IncidentOrderBy_Date(incProCod);
        }

        public DataSet View_IncidentOrderBy_LastestUpdate(int incProCod)
        {
            View_Persist vp = new View_Persist();
            return vp.View_IncidentOrderBy_LastestUpdate(incProCod);
        }



        public DataSet View_IncidentOrderBy(int incProCod, string by)
        {
            View_Persist vp = new View_Persist();
            return vp.View_IncidentOrderBy(incProCod, by);
        }





        

        public List<string> consult_projectOfUser(string usuCod)
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

        public DataSet consult_2(string usuCod)
        {
            View_Persist vp = new View_Persist();
            return vp.consult_2(usuCod);
        }

        public DataSet consult_3(string usuCod)
        {
            View_Persist vp = new View_Persist();
            return vp.consult_3(usuCod);
        }

        public DataSet consult_4(string usuNom)
        {
            View_Persist vp = new View_Persist();
            return vp.consult_4(usuNom);
        }

        public List<string> userByProject(int proCod)
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


        public Estado_Logic EstadoInicial()
        {
            View_Persist vp = new View_Persist();
            DataSet ds = vp.EstadoInicial();
            DataTable dt = ds.Tables["estado"];
            string estCod = dt.Rows[0].Field<string>("estCod");
            Estado_Logic el = new Estado_Logic(estCod);
            return el;
        }

        public Estado_Logic EstadoFinal()
        {
            View_Persist vp = new View_Persist();
            DataSet ds = vp.EstadoFinal();
            DataTable dt = ds.Tables["estado"];
            string estCod = dt.Rows[0].Field<string>("estCod");
            Estado_Logic el = new Estado_Logic(estCod);
            return el;
        }
    }
}
