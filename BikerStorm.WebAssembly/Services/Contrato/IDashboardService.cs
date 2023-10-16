using BikerStorm.DTO;

namespace BikerStorm.WebAssembly.Services.Contrato
{
    public interface IDashboardService
    {
        Task<ResponseDTO<DashboardDTO>> Summary();
    }
}
