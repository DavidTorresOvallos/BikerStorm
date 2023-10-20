using Blazored.LocalStorage;
using Blazored.Toast.Services;
using BikerStorm.DTO;
using BikerStorm.WebAssembly.Services.Contrato;

namespace BikerStorm.WebAssembly.Services.Implementacion
{
    public class CartService : ICartService
    {
        private ILocalStorageService _localStorageService;
        private ISyncLocalStorageService _syncLocalStorageService;
        private IToastService _toastService;

        public CartService(ILocalStorageService localStorageService, ISyncLocalStorageService syncLocalStorageService, IToastService toastService)
        {
            this._localStorageService = localStorageService;
            this._syncLocalStorageService = syncLocalStorageService;
            this._toastService = toastService;
        }

        public event Action MostrarItems;

        public async Task AddCart(CarritoDTO model)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if (carrito == null)
                {
                    carrito = new List<CarritoDTO>();
                }

                var encontrado = carrito.FirstOrDefault(c => c.Producto.IdProducto == model.Producto.IdProducto);
                if(encontrado != null)
                {
                    carrito.Remove(encontrado);
                }

                carrito.Add(model);
                await _localStorageService.SetItemAsync("carrito", carrito);

                if(encontrado != null)
                {
                    _toastService.ShowSuccess("El producto fue actualizado en carrito");
                }
                else
                {
                    _toastService.ShowSuccess("El producto fue agregado al carrito");
                }

                MostrarItems.Invoke();
            } catch (Exception ex)
            {
                _toastService.ShowError("No se pudo agregar el producto al carrito");
            }
        }

        public int AmountProducts()
        {
            var carrito = _syncLocalStorageService.GetItem<List<CarritoDTO>>("carrito");
            return carrito == null ? 0 : carrito.Count;
        }

        public async Task CleanCart()
        {
            await _localStorageService.RemoveItemAsync("carrito");
            MostrarItems.Invoke();
        }

        public async Task DeleteCart(int idProduct)
        {
            try
            {
                var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
                if(carrito != null)
                {
                    var elemento = carrito.FirstOrDefault(c => c.Producto.IdProducto == idProduct);
                    if(elemento != null)
                    {
                        carrito.Remove(elemento);
                        await _localStorageService.SetItemAsync("carrito", carrito);
                        MostrarItems.Invoke();
                    }
                }
            }
            catch (Exception ex)
            {

            }
        }

        public async Task<List<CarritoDTO>> GetCarts()
        {
            var carrito = await _localStorageService.GetItemAsync<List<CarritoDTO>>("carrito");
            if(carrito == null)
            {
                carrito = new List<CarritoDTO>();
            }
            return carrito;
        }
    }
}
