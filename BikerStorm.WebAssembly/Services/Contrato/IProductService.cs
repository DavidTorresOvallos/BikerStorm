using BikerStorm.DTO;

namespace BikerStorm.WebAssembly.Services.Contrato
{
    public interface IProductService
    {
        Task<ResponseDTO<List<ProductoDTO>>> List(string buscar);
        Task<ResponseDTO<List<ProductoDTO>>> Directory(string categoria, string buscar);
        Task<ResponseDTO<ProductoDTO>> Get(int id);
        Task<ResponseDTO<ProductoDTO>> Create(ProductoDTO model);
        Task<ResponseDTO<bool>> Edit(ProductoDTO model);
        Task<ResponseDTO<bool>> Delete(int id);
    }
}
