using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class View_Persist
    {

        public DataSet View_GeneralProjects()
        {
            //Tabla:
            //Código
            //Nombre
            //Estado
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT proCod, proNom, proEst FROM proyecto";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "proyecto");
                return ds;
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
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT grpUsuCod FROM grupoUsuario";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "grupoUsuario");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralUsers()
        {
            //Tabla:
            //Nombre
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT usuCod FROM usuario";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "usuario");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GroupUsers(string grpUsuCod)
        {
            //Tabla:
            //Nombre
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT usuGrpUsuCod FROM usuarioGrupoUsuario WHERE usuGrpCod = @usuGrpCod";
                sql.Parameters.AddWithValue("@usuGrpCod", grpUsuCod);
                SQLExecute sqlInsGrpUsu = new SQLExecute();
                DataSet ds = sqlInsGrpUsu.Execute(sql, "usuarioGrupoUsuario");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralIncidents(int incProCod)
        {
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //estado
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCod, incRes, incUsuAsi, incEstCod " + 
                                  "FROM incidente " +
                                  "WHERE incidente.incProCod = @incProCod";
                sql.Parameters.AddWithValue("@incProCod", incProCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_History(int ProCod)
        {
            //Tabla:
            //Integer (código)
            //Fecha (acordate q aca tenes q cambiar el orden de la tabla original para q quede la fecha en segunda posición)
            //Estado inicial
            //Estado final
            //Tiempos (horas)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT histCod, histFec, histEstIni, histEstFin, histTiempo FROM historia" +
                                  "WHERE historia.ProCod = @ProCod";
                sql.Parameters.AddWithValue("@ProCod", ProCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "historia");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralRol()
        {
            //Tabla:
            //codigo
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT rolCod FROM rol";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "rol");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralState()
        {
            //Tabla:
            //Nombre (es el código verdad¿?) igual q en rol y seguridad
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT estCod FROM estado";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "estado");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralSecurity()
        {
            //Tabla:
            //codigo
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT secCod FROM seguridad";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "seguridad");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_UserRol(string usuCod)
        {
            //Tabla:
            //Código (todos los roles del usuario)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT usuRolCod FROM usuarioRol WHERE usuarioRol.usuCod = @usuCod";
                sql.Parameters.AddWithValue("@usuCod", usuCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "usuarioRol");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_UserRol(string usuCod)
        {
            //Tabla:
            //Código (todos los roles del sistema excepto los que tiene ese usuario)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT rolCod FROM rol " +
                                  "WHERE rolCod NOT IN (" +
                                  "SELECT usuRolCod FROM usuarioRol WHERE usuarioRol.usuCod = @usuCod )";
                sql.Parameters.AddWithValue("@usuCod", usuCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "rol");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_NextState(string estCod)
        {
            //Tabla:
            //Código (todos los roles del sistema excepto los que tiene ese usuario)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT estCod FROM estado " +
                                  "WHERE estCod NOT IN (" +
                                  "SELECT estSigEstCod FROM estadoSiguiente WHERE estCod = @estCod )";
                sql.Parameters.AddWithValue("@estCod", estCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "estado");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_RolSecurity(string rolCod)
        {
            //Tabla:
            //Código (todos las seguridades del rol)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT rolSegCod FROM rolSeguridad WHERE rolSeguridad.rolCod = @rolCod";
                sql.Parameters.AddWithValue("@rolCod", rolCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "rolSeguridad");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_RolSecurity(string rolCod)
        {
            //Tabla:
            //Código (todas las seguridades del sistema excepto las que tiene ese rol)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT segCod FROM seguridad " +
                                  "WHERE segCod NOT IN (" +
                                  "SELECT rolSegCod FROM rolSeguridad WHERE rolSeguridad.rolCod = @rolCod)";
                sql.Parameters.AddWithValue("@rolCod", rolCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "seguridad");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_ProjectGroup(int proCod)
        {
            //Tabla:
            //Código (todos los grupos del proyecto)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT proGrpUsuCod FROM proyectoGrupoUsuario WHERE proyectoGrupoUsuario.proCod = @proCod";
                sql.Parameters.AddWithValue("@proCod", proCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "proyectoGrupoUsuario");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_ProjectGroup(int proCod)
        {
            //Tabla:
            //Código (todos los grupos del sistema excepto los que tiene ese proyecto)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT grpUsuCod FROM grupoUsuario " +
                                  "WHERE grpUsuCod NOT IN (" +
                                  "SELECT proGrpUsuCod FROM proyectoGrupoUsuario WHERE proyectoGrupoUsuario.proCod = @proCod)";
                sql.Parameters.AddWithValue("@proCod", proCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "grupoUsuario");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_Option_GroupUser(string grpCod)
        {
            //Tabla:
            //Código (todos los grupos del sistema excepto los que tiene ese proyecto)
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT usuCod FROM usuario " +
                                  "WHERE usuCod NOT IN (" +
                                  "SELECT usuGrpUsuCod FROM usuarioGrupoUsuario WHERE usuarioGrupoUsuario.usuGrpCod = @grpCod)";
                sql.Parameters.AddWithValue("@grpCod", grpCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "usuario");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet Consult_Incident(int incCod)
        {
            //Datos:
            //Categoría
            //Estado
            //Prioridad
            //Severidad
            //Resumen 
            //Descripción
            //Asignado
            //Fecha de reporte
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCatCod, incEstCod, incPriCod, incSevCod, IncRes, incDes, incUsuAsig, incFecIng " +
                                  "FROM incidente " +
                                  "WHERE incidente.incCod = @incCod";
                sql.Parameters.AddWithValue("@incCod", incCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet Consult_HistoryNote(int histCod)
        {
            //Datos:
            //Nota (solo te voy a pasar historia q si tengan notas, eso lo controlo 
            //yo en la interfaz, igual siempre mantene todo en un try y catch ?).
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT histNota " +
                                    "FROM historia " +
                                    "WHERE historia.histCod = @histCod";
                sql.Parameters.AddWithValue("@histCod", histCod);
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "historia");
                return ds;
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
            //nose el orden
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //Estado
            string any = "*";
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCod, incRes, incUsuAsig, incEstCod" +
                                    "FROM incidente " +
                                    "WHERE incidente.incProCod = @incProCod AND " +
                                          "incidente.incEstCod = @incEstCod AND " +
                                          "incidente.incPriCod = @incPriCod AND " +
                                          "incidente.incCatCod = @incCatCod AND " +
                                          "incidente.incUsuAsig = @incUsuAsig AND " +
                                          "incidente.incSevCod = @incSevCod ";

                if (incProCod != 0)
                    sql.Parameters.AddWithValue("@incProCod", incProCod);
                else
                    sql.Parameters.AddWithValue("@incProCod", any);

                if (incEstCod != null)
                    sql.Parameters.AddWithValue("@incEstCod", incEstCod);
                else
                    sql.Parameters.AddWithValue("@incEstCod", any);

                if (incPriCod != null)
                    sql.Parameters.AddWithValue("@incPriCod", incPriCod);
                else
                    sql.Parameters.AddWithValue("@incPriCod", any);

                if (incCatCod != null)
                    sql.Parameters.AddWithValue("@incCatCod", incCatCod);
                else
                    sql.Parameters.AddWithValue("@incCatCod", any);

                if (incUsuAsig != 0)
                    sql.Parameters.AddWithValue("@incUsuAsig", incUsuAsig);
                else
                    sql.Parameters.AddWithValue("@incUsuAsig", any);

                if (incSevCod != null)
                    sql.Parameters.AddWithValue("@incSevCod", incSevCod);
                else
                    sql.Parameters.AddWithValue("@incSevCod", any);


                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //También faltan las vistas de los filtros simples (“simples”je agarrate)


        public DataSet View_IncidentOrderBy_State(int incProCod, string incEstCod)
        {
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //Estado
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCod, incRes, incUsuAsig, incEstCod FROM incidente " +
                                  "WHERE incidente.incProCod = @incProCod AND " +
                                  "incidente.incEstCod = @incEstCod";

                sql.Parameters.AddWithValue("@incProCod", incProCod);
                sql.Parameters.AddWithValue("@incEstCod", incEstCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_Priority(int incProCod, string incPriCod)
        {
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //Estado
            //Prioridad
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCod, incRes, incUsuAsig, incEstCod, incPriCod FROM incidente " +
                                  "WHERE incidente.incProCod = @incProCod AND " +
                                  "incidente.incPriCod = @incPriCod";

                sql.Parameters.AddWithValue("@incProCod", incProCod);
                sql.Parameters.AddWithValue("@incPriCod", incPriCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_Category(int incProCod, string incCatCod)
        {
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //Estado
            //Categoria
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCod, incRes, incUsuAsig, incEstCod, incCatCod FROM incidente " +
                                  "WHERE incidente.incProCod = @incProCod AND " +
                                  "incidente.incCatCod = @incCatCod";

                sql.Parameters.AddWithValue("@incProCod", incProCod);
                sql.Parameters.AddWithValue("@incCatCod", incCatCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_Severity(int incProCod, string incSevCod)
        {
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //Estado
            //Severidad
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCod, incRes, incUsuAsig, incEstCod, incSevCod FROM incidente " +
                                  "WHERE incidente.incProCod = @incProCod AND " +
                                  "incidente.incSevCod = @incSevCod";

                sql.Parameters.AddWithValue("@incProCod", incProCod);
                sql.Parameters.AddWithValue("@incSevCod", incSevCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_Date(int incProCod)
        {
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //Estado
            //Fecha
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCod, incRes, incUsuAsig, incEstCod, incFecIng FROM incidente " +
                                  "WHERE incidente.incProCod = @incProCod";

                sql.Parameters.AddWithValue("@incProCod", incProCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_IncidentOrderBy_LastestUpdate(int incProCod)
        {
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //Estado
            //Fecha
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT incCod, incRes, incUsuAsig, incEstCod, incFecUltAct FROM incidente " +
                                  "WHERE incidente.incProCod = @incProCod " +
                                  "ORDER BY incidente.incFecUltAct";

                sql.Parameters.AddWithValue("@incProCod", incProCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "incidente");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }



        public DataSet View_IncidentOrderBy(int incProCod, string by){
    		string command = "";
		
    		switch (by) {
	    		case "Estado":
    				command = "SELECT incCod, incRes, incUsuAsi, incEstCod FROM incidente " +
							  "WHERE incidente.incProCod = @incProCod " + 
							  "ORDER BY incidente.incEstCod";
	    			break;
		    	case "Prioridad":
		    		command = "SELECT incCod, incRes, incUsuAsi, incEstCod, incPriCod FROM incidente " +
							  "WHERE incidente.incProCod = @incProCod " + 
							  "ORDER BY incidente.incPriCod";
		    		break;
		    	case "Categoria":
    				command = "SELECT incCod, incRes, incUsuAsi, incEstCod, incCatCod FROM incidente " +
							  "WHERE incidente.incProCod = @incProCod " + 
							  "ORDER BY incidente.incCatCod";
	    			break;
		    	case "Severidad":
    				command = "SELECT incCod, incRes, incUsuAsi, incEstCod, incSevCod FROM incidente " +
							  "WHERE incidente.incProCod = @incProCod " + 
							  "ORDER BY incidente.incSevCod";
	    			break;
		    	case "Fecha de reporte":
    				command = "SELECT incCod, incRes, incUsuAsi, incEstCod, incFecIng FROM incidente " +
								  "WHERE incidente.incProCod = @incProCod " +
								  "ORDER BY incidente.incFecIng";
				    break;
    			case "Ultima modificacion":
	    			command = "SELECT incCod, incRes, incUsuAsi, incEstCod, incFecUltAct FROM incidente " +
							  "WHERE incidente.incProCod = @incProCod " +
							  "ORDER BY incidente.incFecUltAct";
		    		break;
		        }
		    try
		    {
               	SqlCommand sql = new SqlCommand();
               	sql.CommandText = command;
			    sql.Parameters.AddWithValue("@incProCod", incProCod);            
    			SQLExecute sqlIns = new SQLExecute();
    			DataSet ds = sqlIns.Execute(sql, "incidente");
               	return ds;
           	}
           	catch (SqlException sqlex)
           	{
               	throw sqlex;
           	}
	    }







        public DataSet consult_projectOfUser(string usuCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT proCod, proNom FROM ProjectByUser WHERE usuCod = @usuCod";

                sql.Parameters.AddWithValue("@usuCod", usuCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "ProjectByUser");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
        
        public DataSet consult_2(string usuCod){
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT segCod " +
                                  "FROM seguridadRol " +
                                  "WHERE seguridadRol.rolCod IN " +
                                  "(SELECT rolCod FROM rolUsuario r WHERE r.usuCod = @usuCod) ";

                sql.Parameters.AddWithValue("@usuCod", usuCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "seguridadRol");
                return ds;
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
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * " +
                                  "FROM usuario " +
                                  "WHERE usuNom = @usuCod";

                sql.Parameters.AddWithValue("@usuCod", usuCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "usuario");
                return ds;
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
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT rolCod " +
                                  "FROM rolUsuario " +
                                  "WHERE usuNom = @usuNom";

                sql.Parameters.AddWithValue("@usuNom", usuNom);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "rolUsuario");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet userByProject(int proCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT usuCod FROM UserByProject WHERE proCod = @proCod";

                sql.Parameters.AddWithValue("@proCod", proCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "UserByProject");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralCategory()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM categoria";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "categoria");
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralPriority()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM prioridad";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "prioridad");
                
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet View_GeneralSeverity()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT * FROM severidad";
                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "severidad");
                
                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }


        public DataSet EstadoInicial()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT estCod FROM estado WHERE estIni = 0x1";

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "estado");

                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public DataSet EstadoFinal()
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT estCod FROM estado WHERE estFin = 0x1";

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "estado");

                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }


        public DataSet EstadosSiguientes(string estCod)
        {
            try
            {
                SqlCommand sql = new SqlCommand();
                sql.CommandText = "SELECT estSigEstCod FROM estadoSiguiente WHERE estCod = @estCod";

                sql.Parameters.AddWithValue("@estCod", estCod);

                SQLExecute sqlIns = new SQLExecute();
                DataSet ds = sqlIns.Execute(sql, "estadoSiguiente");

                return ds;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }

        }






    }
}
