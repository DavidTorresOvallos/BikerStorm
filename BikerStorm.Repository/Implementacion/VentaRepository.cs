using BikerStorm.Model;
using BikerStorm.Repository.Contrato;
using BikerStorm.Repository.DBContext;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.Repository.Implementacion
{
    public class VentaRepository : GenericRepository<Venta>, IVentaRepository
    {
        private readonly BikerStormContext _dbContext;

        public VentaRepository(BikerStormContext dbContext) : base(dbContext) 
        {
            this._dbContext = dbContext;
        }

        public async Task<Venta> Register(Venta model)
        {
            Venta ventaGenerada = new Venta();

            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach(DetalleVenta dv in model.DetalleVenta)
                    {
                        Producto producto_encontrado = _dbContext.Productos.Where(p => p.IdProducto == dv.IdProducto).First();
                        
                        producto_encontrado.Cantidad = producto_encontrado.Cantidad - dv.Cantidad;
                        _dbContext.Productos.Update(producto_encontrado);
                    }
                    await _dbContext.SaveChangesAsync();

                    await _dbContext.Venta.AddAsync(model);
                    await _dbContext.SaveChangesAsync();
                    ventaGenerada = model;
                    transaction.Commit();
                }
                catch
                {
                    transaction.Rollback();
                    throw;
                }
            }
            return ventaGenerada;
        }
    }
}
