using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SeguimientoIncidentesBD1.persist
{
    public class Usuario_Persist
    {
        private string usuCod;
        private string usuPass;
        private string usuNom;
        private string usuMail;
        private IList<string> usuRol;
    }
}
