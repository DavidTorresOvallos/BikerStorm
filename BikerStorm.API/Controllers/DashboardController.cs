using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using BikerStorm.Service.Contrato;
using BikerStorm.DTO;
using BikerStorm.Service.Implementacion;

namespace BikerStorm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly IDashboardService _service;

        public DashboardController(IDashboardService service)
        {
            this._service = service;
        }

        [HttpPut("Resumen")]
        public IActionResult Resumen()
        {
            var response = new ResponseDTO<DashboardDTO>();

            try
            {
                response.EsCorrecto = true;
                response.Resultado = _service.Resumen();
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
