using BikerStorm.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStorm.DTO;

namespace BikerStorm.Service.Contrato
{
    public interface IProductService
    {
        Task<List<ProductoDTO>> List(string buscar);
        Task<List<ProductoDTO>> Directory(string categoria, string buscar);
        Task<ProductoDTO> Get(int id);
        Task<ProductoDTO> Create(ProductoDTO model);
        Task<bool> Edit(ProductoDTO model);
        Task<bool> Delete(int id);
    }
}
