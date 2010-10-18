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
        public void RolDelete()
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(this.rolCod);
                rolPersist.RolDelete();
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //actualiza la descripción de un rol
        public void RolDesUpdate(string nuevaDesc)
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(this.rolCod);
                //primero actualizo la nueva descripción
                rolPersist.RolDesUpdate(nuevaDesc);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //agrega una nueva seguridad relacionada al rol
        public void RolSegAdd(string rolSeg)
        {
            try
            {
                //actualizo la lista de seguridades
                this.rolSeg.Add(rolSeg);
                Rol_Persist rolPersist = new Rol_Persist(this.rolCod);
                rolPersist.RolSegAdd(rolSeg);              
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
