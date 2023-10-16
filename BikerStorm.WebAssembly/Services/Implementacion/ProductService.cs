using BikerStorm.DTO;
using System.Net.Http.Json;
using BikerStorm.WebAssembly.Services.Contrato;

namespace BikerStorm.WebAssembly.Services.Implementacion
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ResponseDTO<ProductoDTO>> Create(ProductoDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto/Crear", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<ProductoDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Producto/Eliminar/{id}");
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> Directory(string categoria, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Catalogo/{categoria}/{buscar}");
        }

        public async Task<ResponseDTO<bool>> Edit(ProductoDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Producto/Editar", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<ProductoDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<ProductoDTO>>($"Producto/Obtener/{id}");
        }

        public async Task<ResponseDTO<List<ProductoDTO>>> List(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<ProductoDTO>>>($"Producto/Lista/{buscar}");
        }
    }
}
