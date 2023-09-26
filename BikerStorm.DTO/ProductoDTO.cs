using BikerStorm.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.DTO
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        [Required(ErrorMessage = "Ingrese Nombre")]
        public string? NombreImagen { get; set; }


        [Required(ErrorMessage = "Ingrese Descripción")]
        public string? Descripcion { get; set; }


        [Required(ErrorMessage = "Ingrese Precio")]
        public decimal? Precio { get; set; }


        [Required(ErrorMessage = "Ingrese Precio Oferta")]
        public decimal? PrecioOferta { get; set; }


        [Required(ErrorMessage = "Ingrese Cantidad")]
        public int? Cantidad { get; set; }


        [Required(ErrorMessage = "Ingrese Imagen")]
        public string? UrlImagen { get; set; }

        public DateTime? FechaRegistro { get; set; }

        public CategoriaDTO? IdCategoriaNavigation { get; set; }

        public int? IdCategoria { get; set; }

    }
}
