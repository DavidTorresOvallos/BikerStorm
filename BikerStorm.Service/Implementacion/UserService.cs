using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikerStorm.Model;
using BikerStorm.DTO;
using BikerStorm.Repository.Contrato;
using BikerStorm.Service.Contrato;
using AutoMapper;
using System.Linq.Expressions;

namespace BikerStorm.Service.Implementacion
{
    public class UserService : IUserService
    {
        private readonly IGenericRepository<Usuario> _modelRepository;
        private readonly IMapper _mapper;
        public UserService(IGenericRepository<Usuario> modelRepository, IMapper mapper)
        {
            this._modelRepository = modelRepository;
            this._mapper = mapper;
        }

        public async Task<SesionDTO> Authorization(LoginDTO model)
        {
            try
            {
                var consulta = _modelRepository.Request(p => p.Correo == p.Correo && p.Clave == model.Clave);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if(fromDbModel != null)
                {
                    return _mapper.Map<SesionDTO>(fromDbModel);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencias");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<UsuarioDTO> Create(UsuarioDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Usuario>(model);
                var replyModel = _modelRepository.Create(dbModel);

                if (replyModel.Id != 0)
                {
                    return _mapper.Map<UsuarioDTO>(replyModel);
                }
                else
                {
                    throw new TaskCanceledException("No se pudo crear");
                }
            }
            catch (Exception ex) 
            {
                throw ex;
            }
        }


        public async Task<bool> Delete(int id)
        {
            try
            {
                var consulta = _modelRepository.Request(p => p.IdUsuario == id);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    var reply = await _modelRepository.Delete(fromDbModel);
                    if (!reply)
                    {
                        throw new TaskCanceledException("No se pudo eliminar");
                    }
                    return reply;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<bool> Edit(UsuarioDTO model)
        {
            try
            {
                var consulta = _modelRepository.Request(p => p.IdUsuario == model.IdUsuario);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Nombre = model.Nombre;
                    fromDbModel.Correo = model.Correo;
                    fromDbModel.Clave = model.Clave;
                    var reply = await _modelRepository.Edit(fromDbModel);

                    if (!reply)
                    {
                        throw new TaskCanceledException("No se pudo editar");
                    }
                    return reply;
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron resultados");
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }


        public async Task<UsuarioDTO> Get(int id)
        {
            try
            {
                var consulta = _modelRepository.Request(p => p.IdUsuario.Equals(id));
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if(fromDbModel != null)
                {
                    return _mapper.Map<UsuarioDTO>(fromDbModel);
                }
                else
                {
                    throw new TaskCanceledException("No se encontraron coincidencias");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<UsuarioDTO>> List(string rol, string buscar)
        {
            try
            {
                var consulta = _modelRepository.Request(p =>
                p.IdRolNavigation.Descripcion == rol &&
                string.Concat(p.Nombre.ToLower(), p.Correo.ToLower()).Contains(buscar.ToLower())
                );

                List<UsuarioDTO> list = _mapper.Map<List<UsuarioDTO>>(await consulta.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
