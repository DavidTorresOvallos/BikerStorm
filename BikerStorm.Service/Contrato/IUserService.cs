using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStorm.DTO;

namespace BikerStorm.Service.Contrato
{
    public interface IUserService
    {
        Task<List<UsuarioDTO>> List(string rol, string buscar);
        Task<UsuarioDTO> Get(int id);
        Task<SesionDTO> Authorization(LoginDTO model);
        Task<UsuarioDTO> Create(UsuarioDTO model);
        Task<bool> Edit(UsuarioDTO model);
        Task<bool> Delete(int id);
    }
}
