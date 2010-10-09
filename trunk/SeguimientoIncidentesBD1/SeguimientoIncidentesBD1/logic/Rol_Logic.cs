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
        private string rolDesc;
        //un rol tiene una lista de seguridades, cada seguridad se corresponde con un nombre programa de la interfaz
        private RolSeguridad_Logic rolSeg;

        public string RolCod
        {
            get { return rolCod; }
            set { rolCod = value; }
        }

        public string RolDesc
        {
            get { return rolDesc; }
            set { rolDesc = value; }
        }
        
        public RolSeguridad_Logic RolSeg
        {
            get { return rolSeg; }
            set { rolSeg = value; }
        }

        public Rol_Logic(string rolCod, string rolDesc, string[] rolSeg){
            this.rolCod = rolCod;
            this.rolDesc = rolDesc;
            this.rolSeg = new RolSeguridad_Logic(rolCod, rolSeg);
        }

        //cada entidad debe tener un constructor que solo reciba la clave, y en dicho caso haga la busqueda en la BD
        //y cargue los datos a partir de los datos del rol en la base
        public Rol_Logic(string rolCod)
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(rolCod);
                this.rolCod = rolPersist.RolCod;
                this.rolDesc = rolPersist.RolDesc;
                this.rolSeg = new RolSeguridad_Logic(rolCod);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        //persiste un rol en la base de datos
        public void RolPersist()
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(this.rolCod, this.rolDesc);
                rolPersist.RolCreate();
                //persisto las seguridades del rol
                this.rolSeg.RolSeguridadPersist();
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
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        //persiste un rol en la base de datos
        public void RolModify(string rolCod, string nuevaDesc, string[] rolSeg)
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(rolCod);
                //primero actualizo la nueva descripción
                rolPersist.RolDescUpdate(nuevaDesc);
                //actualizo las seguridades del rol
                this.rolSeg.RolSeguridadModify(rolSeg);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
