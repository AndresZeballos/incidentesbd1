using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Rol_Logic
    {
        private string rolCod;
        private string rolDesc;
        //un rol tiene una lista de seguridades, cada seguridad se corresponde con un nombre programa de la interfaz
        private int[] rolSegId;

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
        
        public int[] RolSegId
        {
            get { return rolSegId; }
            set { rolSegId = value; }
        }

        public Rol_Logic(string rolCod, string rolDesc, int[]rolSegId){
            this.rolCod = rolCod;
            this.rolDesc = rolDesc;
            this.rolSegId = rolSegId;
        }

        public Rol_Logic(string rolCod, int[]rolSegId){
            this.rolCod = rolCod;
            this.rolSegId = rolSegId;
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
                this.RolSegId = rolPersist.RolSegId;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        //persiste un rol en la base de datos
        public void RolPersist(){
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(this.rolCod, this.rolDesc, this.rolSegId);
                rolPersist.RolCreate();
            }
            catch (Exception ex)
            {
                //el metodo CrearRol de la clase Rol_Persist debe hacer un throw de la excepcion en caso de que no
                //se pueda persistir el rol en la base de datos.
                //ESTE MANEJO DE EXPCECIONES DEBE REALIZARSE SIEMPRE
                System.Windows.Forms.MessageBox.Show(ex.Message);
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
        public void RolModify(string rolCod, string nuevaDesc, int[] rolSegId)
        {
            try
            {
                Rol_Persist rolPersist = new Rol_Persist(rolCod);
                //primero actualizo la nueva descripción
                rolPersist.RolDescUpdate(nuevaDesc);
                //luego comparo uno a uno los rolSegId, si no existe, lo agrego
                foreach (int rolSeg in rolSegId)
                {
                    Boolean rolExiste = false;
                    foreach (int rolSegExistente in rolPersist.RolSegId)
                    {
                        if (rolSeg == rolSegExistente)
                        {
                            rolExiste = true;
                            break;
                        }
                    }
                    if (!rolExiste)
                    {
                        rolPersist.RolSegCodAdd(rolSeg);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }
    }
}
