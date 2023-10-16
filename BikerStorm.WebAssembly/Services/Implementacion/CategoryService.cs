using BikerStorm.DTO;
using BikerStorm.WebAssembly.Services.Contrato;
using System.Net.Http.Json;

namespace BikerStorm.WebAssembly.Services.Implementacion
{
    public class CategoryService : ICategoryService
    {
        private readonly HttpClient _httpClient;

        public CategoryService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Create(CategoriaDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/Crear", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<CategoriaDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Categoria/Eliminar/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(CategoriaDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Categoria/Editar", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<CategoriaDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<CategoriaDTO>>($"Categoria/Obtener/{id}");
        }

        public async Task<ResponseDTO<List<CategoriaDTO>>> List(string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<CategoriaDTO>>>($"Categoria/Lista/{buscar}");
        }
    }
}
