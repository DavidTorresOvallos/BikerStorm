using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.DTO
{
    public class LoginDTO
    {
        [Required(ErrorMessage = "Ingrese Correo")]
        public string? Correo {  get; set; }

        [Required(ErrorMessage = "Ingrese su Contraseña")]
        public string? Clave { get; set; }
    }
}
