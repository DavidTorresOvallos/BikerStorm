using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BikerStorm.Service.Contrato;
using BikerStorm.DTO;

namespace BikerStorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [HttpGet("Lista/{rol:alpha}/{buscar:alpha?}")]
        public async Task<IActionResult> Lista(string rol, string buscar = "NA")
        {
            var response = new ResponseDTO<List<UsuarioDTO>>();

            try
            {
                if (buscar == "NA")
                {
                    buscar = "";
                }
                response.EsCorrecto = true;
                response.Resultado = await _userService.List(rol, buscar);
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
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Get(Id);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPost("Crear")]
        public async Task<IActionResult> Crear([FromBody] UsuarioDTO model)
        {
            var response = new ResponseDTO<UsuarioDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Create(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPost("Autorizacion")]
        public async Task<IActionResult> Autorizacion([FromBody] LoginDTO model)
        {
            var response = new ResponseDTO<SesionDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Authorization(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPut("Editar")]
        public async Task<IActionResult> Editar([FromBody] UsuarioDTO model)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Edit(model);
            }
            catch (Exception ex)
            {
                response.EsCorrecto = false;
                response.Mensaje = ex.Message;
            }
            return Ok(response);
        }


        [HttpPut("Eliminar")]
        public async Task<IActionResult> Eliminar(int Id)
        {
            var response = new ResponseDTO<bool>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _userService.Delete(Id);
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
