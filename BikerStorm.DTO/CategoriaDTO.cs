using BikerStorm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.DTO
{
    public class CategoriaDTO
    {
        public int IdCategoria { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        public string? Descripcion { get; set; }
    }
}
