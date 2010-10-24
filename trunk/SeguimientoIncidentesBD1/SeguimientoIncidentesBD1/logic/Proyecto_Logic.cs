using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Proyecto_Logic
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

        public Proyecto_Logic(string proNom, string proDes, string proEst)
        {
            this.proNom = proNom;
            this.proDes = proDes;
            this.proEst = proEst;
        }

        //cada entidad debe tener un constructor que solo reciba la clave, y en dicho caso haga la busqueda en la BD
        //y cargue los datos a partir de los datos del usuario en la base
        public Proyecto_Logic(int proCod)
        {
            try
            {
                Proyecto_Persist proPersist = new Proyecto_Persist(proCod);
                this.proCod = proPersist.ProCod;
                this.proNom = proPersist.ProNom;
                this.proDes = proPersist.ProDes;
                this.proEst = proPersist.ProEst;
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        //persiste un proyecto en la base de datos
        public void ProyectoPersist()
        {
            try
            {
                Proyecto_Persist proPersist = new Proyecto_Persist(this.proNom, this.proDes, this.proEst);
                proPersist.ProyectoCreate();
                this.ProCod = proPersist.ProCod;
            }
            catch (SqlException sqlex)
            {
                //el metodo CrearRol de la clase Proyecto_Persist debe hacer un throw de la excepcion en caso de que no
                //se pueda persistir el rol en la base de datos.
                //ESTE MANEJO DE EXPCECIONES DEBE REALIZARSE SIEMPRE
                throw sqlex;
            }
        }

        //actualiza los diferentes atributos del usuario, menos sus roles
        public void ProyectoUpdate(string proNom, string proDes, string proEst)
        {
            try
            {
                Proyecto_Persist proPersist = new Proyecto_Persist(this.proCod);
                //actualizo los nuevos datos
                proPersist.ProyectoUpdate(proNom, proDes, proEst);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }

        public void ProGrpAdd(string grpUsuCod)
        {
            try
            {
                //actualizo la lista de seguridades
                //this.usuGrpCod.Add(grpUsuCod);
                Proyecto_Persist proPersist = new Proyecto_Persist(this.proCod);
                proPersist.ProGrpAdd(grpUsuCod);
            }
            catch (SqlException sqlex)
            {
                throw sqlex;
            }
        }
    }
}
