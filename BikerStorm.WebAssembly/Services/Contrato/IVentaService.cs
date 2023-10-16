using BikerStorm.DTO;

namespace BikerStorm.WebAssembly.Services.Contrato
{
    public interface IVentaService
    {
        Task<ResponseDTO<VentaDTO>> Register(VentaDTO model);
    }
}
