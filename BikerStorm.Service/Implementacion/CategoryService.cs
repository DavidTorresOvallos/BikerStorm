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
    public class CategoryService : ICategoryService
    {
        private readonly IGenericRepository<Categoria> _modelRepository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Categoria> modelRepository, IMapper mapper)
        {
            this._modelRepository = modelRepository;
            this._mapper = mapper;
        }

        public async Task<CategoriaDTO> Create(CategoriaDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Categoria>(model);
                var replyModel = _modelRepository.Create(dbModel);

                if (replyModel.Id != 0)
                {
                    return _mapper.Map<CategoriaDTO>(replyModel);
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
                var consulta = _modelRepository.Request(p => p.IdCategoria == id);
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

        public async Task<bool> Edit(CategoriaDTO model)
        {
            try
            {
                var consulta = _modelRepository.Request(p => p.IdCategoria == model.IdCategoria);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.Descripcion = model.Descripcion;
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<CategoriaDTO> Get(int id)
        {
            try
            {
                var consulta = _modelRepository.Request(p => p.IdCategoria.Equals(id));
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<CategoriaDTO>(fromDbModel);
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

        public async Task<List<CategoriaDTO>> List(string buscar)
        {
            try
            {
                var consulta = _modelRepository.Request(p =>
                string.Concat(p.Descripcion.ToLower()).Contains(buscar.ToLower())
                );

                List<CategoriaDTO> list = _mapper.Map<List<CategoriaDTO>>(await consulta.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
