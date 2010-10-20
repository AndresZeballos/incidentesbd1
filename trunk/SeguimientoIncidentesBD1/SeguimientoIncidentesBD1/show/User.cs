using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeguimientoIncidentesBD1;
using SeguimientoIncidentesBD1.persist;

namespace WindowsFormsASeguimientoIncidentesBD1.show
{
    public class User
    {

        private Usuario_Persist currentUser;
        public String codUsuCurrent;

        public Usuario_Persist InstanceUser()
        {
            if (currentUser == null)
            {
                currentUser = new Usuario_Persist(this.codUsuCurrent);
            }
            return currentUser;

        }
    }
}
