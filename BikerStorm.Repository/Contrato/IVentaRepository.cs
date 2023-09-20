using BikerStorm.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.Repository.Contrato
{
    public interface IVentaRepository : IGenericRepository<Venta>
    {
        Task<Venta> Register (Venta model);
    }
}
