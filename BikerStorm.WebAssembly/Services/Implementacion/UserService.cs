using BikerStorm.DTO;
using BikerStorm.WebAssembly.Services.Contrato;
using System.Net.Http.Json;

namespace BikerStorm.WebAssembly.Services.Implementacion
{
    public class UserService : IUserService
    {
        public readonly HttpClient _httpClient;

        public UserService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<ResponseDTO<SesionDTO>> Authorization(LoginDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Autorizacion", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<SesionDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Create(UsuarioDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Crear", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<UsuarioDTO>>();
            return result!;
        }

        public async Task<ResponseDTO<bool>> Delete(int id)
        {
            return await _httpClient.DeleteFromJsonAsync<ResponseDTO<bool>>($"Usuario/Eliminar/{id}");
        }

        public async Task<ResponseDTO<bool>> Edit(UsuarioDTO model)
        {
            var response = await _httpClient.PostAsJsonAsync("Usuario/Editar", model);
            var result = await response.Content.ReadFromJsonAsync<ResponseDTO<bool>>();
            return result!;
        }

        public async Task<ResponseDTO<UsuarioDTO>> Get(int id)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<UsuarioDTO>>($"Usuario/Obtener/{id}");
        }

        public async Task<ResponseDTO<List<UsuarioDTO>>> List(string rol, string buscar)
        {
            return await _httpClient.GetFromJsonAsync<ResponseDTO<List<UsuarioDTO>>>($"Usuario/Lista/{rol}/{buscar}");
        }
    }
}
