using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

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
            return null;
        }

        public DataSet View_GeneralGroups()
        {
            //Tabla:
            //Código
            return null;
        }

        public DataSet View_GeneralUsers()
        {
            //Tabla:
            //Nombre
            return null;
        }

        public DataSet View_GeneralIncidents()
        {
            //Tabla:
            //Código
            //Resumen
            //Asignado
            //estado
            return null;
        }

        public DataSet View_History()
        {
            //Tabla:
            //Integer (código)
            //Fecha (acordate q aca tenes q cambiar el orden de la tabla original para q quede la fecha en segunda posición)
            //Estado inicial
            //Estado final
            //Tiempos (horas)
            return null;
        }

        public DataSet View_GeneralRol(){
            //Tabla:
            //codigo
            return null;
        }

        public DataSet View_GeneralState(){
            //Tabla:
            //Nombre (es el código verdad¿?) igual q en rol y seguridad
            return null;
        }

        public DataSet View_GeneralSecurity(){
            //Tabla:
            //codigo
            return null;
        }

        public DataSet View_UserRol(int usuCod){
            //Tabla:
            //Código (todos los roles del usuario)
            return null;
        }

        public DataSet View_Option_UserRol(int usuCod){
            //Tabla:
            //Código (todos los roles del sistema excepto los que tiene ese usuario)
            return null;
        }

        public DataSet View_RolSecurity(string rolCod){
            //Tabla:
            //Código (todos las seguridades del rol)
            return null;
        }

        public DataSet View_Option_RolSecurity(string rolCod){
            //Tabla:
            //Código (todas las seguridades del sistema excepto las que tiene ese rol)
            return null;
        }

        public DataSet View_ProjectGroup(int proCod){
            //Tabla:
            //Código (todos los grupos del proyecto)
            return null;
        }

        public DataSet View_Option_ProjectGroup (string gruCod){
            //Tabla:
            //Código (todos los grupos del sistema excepto los que tiene ese proyecto)
            return null;
        }

    }
}
