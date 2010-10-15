using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Rol_Logic
    {
        private string rolCod;
        private string rolDes;
        //un rol tiene una lista de seguridades, cada seguridad se corresponde con un nombre programa de la interfaz
        private IList<string> rolSeg;

        public string RolCod
        {
            get { return rolCod; }
            set { rolCod = value; }
        }

        public string RolDes
        {
            get { return rolDes; }
            set { rolDes = value; }
        }
        
        //solo necesito tener el segCod
        public IList<string> RolSeg
        {
            get { return rolSeg; }
            set { rolSeg = value; }
        }

        public Rol_Logic(string rolCod, string rolDes, IList<string> rolSeg)
        {
            this.rolCod = rolCod;
            this.rolDes = rolDes;
            this.rolSeg = rolSeg;
        }

        //cada entidad debe tener un constructor que solo reciba la clave, y en dicho caso haga la busqueda en la BD
        //y cargue los datos a partir de los datos del rol en la base
        public Rol_Logic(string rolCod)
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(rolCod);
                this.rolCod = rolPersist.RolCod;
                this.rolDes = rolPersist.RolDes;
                this.rolSeg = rolPersist.RolSeg;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //persiste un rol en la base de datos
        public void RolPersist()
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(this.rolCod, this.rolDes, this.rolSeg);
                rolPersist.RolCreate();
                //persisto las seguridades del rol
            }
            catch (SqlException sqlex)
            {
                //el metodo CrearRol de la clase Rol_Persist debe hacer un throw de la excepcion en caso de que no
                //se pueda persistir el rol en la base de datos.
                //ESTE MANEJO DE EXPCECIONES DEBE REALIZARSE SIEMPRE
                throw sqlex;
            }
        }

        //persiste un rol en la base de datos
        public void RolDelete(string rolCod)
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(rolCod);
                rolPersist.RolDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //actualiza la descripción de un rol
        public void RolDesUpdate(string rolCod, string nuevaDesc)
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(rolCod);
                //primero actualizo la nueva descripción
                rolPersist.RolDesUpdate(nuevaDesc);
                //actualizo las seguridades del rol
                //this.rolSeg.RolSeguridadModify(rolSeg);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //actualiza la lista de seguridades asociadas al rol
        public void RolSegUpdate(string rolCod, IList<string> rolSeg)
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(rolCod);
                
                //tengo que comparar la nueva lista con la actual e incovar rol RolSegUpdate pero solo de a una
                //seguridad nueva

                //rolPersist.RolSegUpdate(rolSeg);
                

            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        internal 
    }
}
