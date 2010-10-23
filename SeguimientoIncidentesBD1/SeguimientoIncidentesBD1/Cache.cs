﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SeguimientoIncidentesBD1.logic;

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
        
        public Usuario_Logic Usuario { get; set; }

        public GrupoUsuario_Logic Grupo { get; set; }

        public Proyecto_Logic Proyecto { get; set; }

        public Cache()
        {
        }
    }
}
