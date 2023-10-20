using BikerStorm.DTO;

namespace BikerStorm.WebAssembly.Services.Contrato
{
    public interface ICartService
    {
        event Action MostrarItems;

        int AmountProducts();
        Task AddCart(CarritoDTO model);
        Task DeleteCart(int idProduct);
        Task<List<CarritoDTO>> GetCarts();
        Task CleanCart();
    }
}
