using BikerStorm.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStorm.DTO;

namespace BikerStorm.Service.Contrato
{
    public interface IVentaService
    {
        Task<VentaDTO> RegisterSale(int id);
    }
}
