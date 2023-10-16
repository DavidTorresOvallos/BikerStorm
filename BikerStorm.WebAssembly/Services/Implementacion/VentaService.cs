using BikerStorm.DTO;
using BikerStorm.WebAssembly.Services.Contrato;
using System.Net.Http.Json;

namespace BikerStorm.WebAssembly.Services.Implementacion
{
    public class VentaService : IVentaService
    {
        private readonly HttpClient _httpClient;

        public VentaService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ResponseDTO<VentaDTO>> Register(VentaDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Venta/Registrar", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<VentaDTO>>();
            return result!;
        }
    }
}
