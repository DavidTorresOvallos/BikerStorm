

using BikerStorm.DTO;

namespace BikerStorm.WebAssembly.Services.Contrato
{
    public interface ICategoryService
    {
        Task<ResponseDTO<List<CategoriaDTO>>> List(string buscar);
        Task<ResponseDTO<CategoriaDTO>> Get(int id);
        Task<ResponseDTO<CategoriaDTO>> Create(CategoriaDTO model);
        Task<ResponseDTO<bool>> Edit(CategoriaDTO model);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
