using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Seguridad_Logic
    {
        private string segCod;
        private string segDes;
        
        public string SegCod
        {
            get { return segCod; }
            set { segCod = value; }
        }

        public string SegDes
        {
            get { return segDes; }
            set { segDes = value; }
        }
        
        public Seguridad_Logic(string segCod, string segDes){
            this.segCod = segCod;
            this.segDes = segDes;
        }

        //cada entidad debe tener un constructor que solo reciba la clave, y en dicho caso haga la busqueda en la BD
        //y cargue los datos a partir de los datos del rol en la base
        public Seguridad_Logic(string segCod)
        {
            try
            {
                this.segCod = segCod;
                Seguridad_Persist segPersist = new Seguridad_Persist(segCod);
                this.segDes = segPersist.SegDes;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //persiste una seguridad en la base de datos
        public void SeguridadPersist(){
            try
            {
                Seguridad_Persist segPersist = new Seguridad_Persist(this.segDes);
                segPersist.SeguridadCreate();
            }
            catch (SqlException sqlex)
            {
                //el metodo CrearRol de la clase Seguridad_Persist debe hacer un throw de la excepcion en caso de que no
                //se pueda persistir el rol en la base de datos.
                //ESTE MANEJO DE EXPCECIONES DEBE REALIZARSE SIEMPRE
                throw sqlex;
            }
        }

        //persiste un rol en la base de datos
        public void SeguridadDelete(string segCod)
        {
            try
            {
                Seguridad_Persist segPersist = new Seguridad_Persist(segCod);
                segPersist.SeguridadDelete("");
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //Cambia la descripción de una seguridad
        public void SeguridadModify(string segCod, string nuevaDesc)
        {
            try
            {
                Seguridad_Persist segPersist = new Seguridad_Persist(segCod);
                //primero actualizo la nueva descripción
                segPersist.SeguridadDescUpdate(nuevaDesc);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
