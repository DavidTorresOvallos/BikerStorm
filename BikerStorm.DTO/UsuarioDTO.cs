using BikerStorm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.DTO
{
    public class UsuarioDTO
    {
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Ingrese nombre completo")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese correo")]
        public string? Correo { get; set; }

        public string? Telefono { get; set; }

        public int? IdRol { get; set; }

        public string? UrlFoto { get; set; }

        public string? NombreFoto { get; set; }

        [Required(ErrorMessage = "Ingrese su Contraseña")]
        public string? Clave { get; set; }

        [Required(ErrorMessage = "Confirme su Contraseña")]
        public string? ConfirmarClave { get; set; }

        public bool? EsActivo { get; set; }

        public virtual Rol? IdRolNavigation { get; set; }

    }
}
