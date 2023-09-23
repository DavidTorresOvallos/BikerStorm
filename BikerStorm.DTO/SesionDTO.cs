﻿using BikerStorm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.DTO
{
    public class SesionDTO
    {
        public int IdUsuario {  get; set; }

        public string? Nombre { get; set; }

        public string? Correo { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }
    }
}
