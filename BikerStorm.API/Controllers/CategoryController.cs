using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BikerStorm.Service.Contrato;
using BikerStorm.DTO;

namespace BikerStorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        [HttpGet("Lista/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string buscar = "NA")
        {
            var responde = new ResponseDTO<List<CategoriaDTO>>();

            try
            {
                if(buscar == "NA")
                {
                    buscar = "";
                }
                responde.EsCorrecto = true;
                responde.Resultado = await _categoryService.List(buscar);
            }
            catch (Exception ex)
            {
                responde.EsCorrecto = false;
                responde.Mensaje = ex.Message;
            }
            return Ok(responde);
        }

        [HttpGet("Obtener/{Id:int}")]
        public async Task<IActionResult> Obtener(int Id)
        {
            var responde = new ResponseDTO<CategoriaDTO>();

            try
            {
                responde.EsCorrecto = true;
                responde.Resultado = await _categoryService.Get(Id);
            }
            catch (Exception ex)
            {
                responde.EsCorrecto = false;
                responde.Mensaje = ex.Message;
            }
            return Ok(responde);
        }

        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] CategoriaDTO model)
        {
            var responde = new ResponseDTO<CategoriaDTO>();

            try
            {
                responde.EsCorrecto = true;
                responde.Resultado = await _categoryService.Create(model);
            }
            catch (Exception ex)
            {
                responde.EsCorrecto = false;
                responde.Mensaje = ex.Message;
            }
            return Ok(responde);
        }

        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] CategoriaDTO model)
        {
            var responde = new ResponseDTO<bool>();

            try
            {
                responde.EsCorrecto = true;
                responde.Resultado = await _categoryService.Edit(model);
            }
            catch (Exception ex)
            {
                responde.EsCorrecto = false;
                responde.Mensaje = ex.Message;
            }
            return Ok(responde);
        }

        [HttpPut("Eliminar/{Id:int}")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var responde = new ResponseDTO<bool>();

            try
            {
                responde.EsCorrecto = true;
                responde.Resultado = await _categoryService.Delete(Id);
            }
            catch (Exception ex)
            {
                responde.EsCorrecto = false;
                responde.Mensaje = ex.Message;
            }
            return Ok(responde);
        }

    }
}
