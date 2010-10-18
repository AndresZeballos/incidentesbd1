using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using SeguimientoIncidentesBD1.persist;

namespace SeguimientoIncidentesBD1.logic
{
    public class Usuario_Logic
    {
        private string usuCod;
        private string usuPass;
        private string usuNom;
        private string usuMail;
        private IList<string> usuRol;
    }
}
