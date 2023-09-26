using BikerStorm.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStorm.DTO;

namespace BikerStorm.Service.Contrato
{
    public interface ICategoryService
    {
        Task<List<CategoriaDTO>> List(string buscar);
        Task<CategoriaDTO> Get(int id);
        Task<CategoriaDTO> Create(CategoriaDTO model);
        Task<bool> Edit(CategoriaDTO model);
        Task<bool> Delete(int id);
    }
}
