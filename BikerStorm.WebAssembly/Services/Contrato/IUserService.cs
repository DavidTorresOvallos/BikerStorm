using BikerStorm.DTO;

namespace BikerStorm.WebAssembly.Services.Contrato
{
    public interface IUserService
    {
        Task<ResponseDTO<List<UsuarioDTO>>> List(string rol, string buscar);
        Task<ResponseDTO<UsuarioDTO>> Get(int id);
        Task<ResponseDTO<SesionDTO>> Authorization(LoginDTO model);
        Task<ResponseDTO<UsuarioDTO>> Create(UsuarioDTO model);
        Task<ResponseDTO<bool>> Edit(UsuarioDTO model);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
