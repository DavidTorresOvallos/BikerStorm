using BikerStorm.DTO;
using BikerStorm.WebAssembly.Services.Contrato;
using System.Net.Http.Json;

namespace BikerStorm.WebAssembly.Services.Implementacion
{
    public class DashboardService : IDashboardService
    {
        private readonly HttpClient _httpClient;

        public DashboardService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<DashboardDTO>> Summary()
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<DashboardDTO>>("Dashboard/Resumen");

        }
    }
}
