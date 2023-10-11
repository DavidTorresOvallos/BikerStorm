using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BikerStorm.Service.Contrato;
using BikerStorm.DTO;
using BikerStorm.Service.Implementacion;

namespace BikerStorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IVentaService _ventaService;

        public VentaController(IVentaService ventaService)
        {
            this._ventaService = ventaService;
        }

        [HttpPost("Registrar")]
        public async Task<IActionResult> Registrar([FromBody] VentaDTO model)
        {
            var response = new ResponseDTO<VentaDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = await _ventaService.RegisterSale(model);
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
