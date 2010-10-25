using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeguimientoIncidentesBD1.logic;
using System.Data;

namespace SeguimientoIncidentesBD1
{
    /// <summary>
    /// En esta clase se guardan todos los atributos que se necesitan ir usando a lo largo del programa. Esta clase debe irse pasando
    /// a través de las diferentes ventanas de la aplicación
    /// </summary>
    public class Cache
    {
        private Usuario_Logic usuario;

        private GrupoUsuario_Logic grupo;

        private Proyecto_Logic proyecto;

        private Estado_Logic estadoInicial;

        private Estado_Logic estadoFinal;

        private Incidente_Logic incidente;

        private Usuario_Logic usuarioSelected;

        private Rol_Logic rol;

        private IncidenteHistoria_Logic historia;

        private Estado_Logic estado;

        public IncidenteHistoria_Logic Historia { get; set; }

        public Usuario_Logic Usuario { get; set; }

        public GrupoUsuario_Logic Grupo { get; set; }

        public Proyecto_Logic Proyecto { get; set; }

        public Estado_Logic EstadoInicial { 
            get { return estadoInicial; }
            set { estadoInicial = value; }

        }

        public Estado_Logic EstadoFinal
        {
            get { return estadoFinal; }
            set { estadoFinal = value; }
        }

        public Incidente_Logic Incidente { get; set; }

        public Usuario_Logic UsuarioSelected { get; set; }

        public Rol_Logic Rol { get; set; }

        public Estado_Logic Estado { get; set; }


        public Cache()
        {
        }
    }
}
