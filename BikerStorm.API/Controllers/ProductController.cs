using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BikerStorm.Service.Contrato;
using BikerStorm.DTO;
using BikerStorm.Service.Implementacion;

namespace BikerStorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet("Lista/{buscar:alpha?")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                response.EsCorrecto = true;
                response.Resultado = await _productService.List(buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("Catalogo/{categoria:alpha}/{buscar:alpha?")]
        public async Task<IActionResult> Catalogo(string categoria, string buscar = "NA")
        {
            var response = new ResponseDTO<List<ProductoDTO>>();

            try
            {
                if (categoria.ToLower() == "todos")
                {
                    categoria = "";
                }
                if (buscar == "NA")
                {
                    buscar = "";
                }

                response.EsCorrecto = true;
                response.Resultado = await _productService.Directory(categoria, buscar);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productService.Get(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpGet("Crear")]
        public async Task<IActionResult> Crear([FromBody] ProductoDTO model)
        {
            var response = new ResponseDTO<ProductoDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productService.Create(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] ProductoDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productService.Edit(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }

        [HttpPut("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _productService.Delete(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }
    }
}
