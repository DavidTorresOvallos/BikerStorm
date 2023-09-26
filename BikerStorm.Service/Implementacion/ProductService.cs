using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using BikerStorm.DTO;
using BikerStorm.Model;
using BikerStorm.Repository.Contrato;
using BikerStorm.Service.Contrato;
using AutoMapper;

namespace BikerStorm.Service.Implementacion
{
    public class ProductService : IProductService
    {
        private readonly IGenericRepository<Producto> _modelRepository;
        private readonly IMapper _mapper;
        public ProductService(IGenericRepository<Producto> modelRepository, IMapper mapper)
        {
            this._modelRepository = modelRepository;
            this._mapper = mapper;
        }


        public async Task<ProductoDTO> Create(ProductoDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Producto>(model);
                var replyModel = _modelRepository.Create(dbModel);

                if (replyModel.Id != 0)
                {
                    return _mapper.Map<ProductoDTO>(replyModel);
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

        public async Task<bool> Edit(ProductoDTO model)
        {
            try
            {
                var consulta = _modelRepository.Request(p => p.IdProducto == model.IdProducto);
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    fromDbModel.NombreImagen = model.NombreImagen;
                    fromDbModel.Descripcion = model.Descripcion;
                    fromDbModel.IdCategoria = model.IdCategoria;
                    fromDbModel.Precio = model.Precio;
                    fromDbModel.PrecioOferta = model.PrecioOferta;
                    fromDbModel.Cantidad = model.Cantidad; 
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

        public async Task<ProductoDTO> Get(int id)
        {
            try
            {
                var consulta = _modelRepository.Request(p => p.IdProducto.Equals(id));
                var fromDbModel = await consulta.FirstOrDefaultAsync();

                if (fromDbModel != null)
                {
                    return _mapper.Map<ProductoDTO>(fromDbModel);
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

        public async Task<List<ProductoDTO>> Directory(string buscar)
        {
            try
            {
                var consulta = _modelRepository.Request(p =>
                p.NombreImagen.ToLower().Contains(buscar.ToLower())
                );

                consulta = consulta.Include(c => c.IdCategoriaNavigation);

                List<ProductoDTO> list = _mapper.Map<List<ProductoDTO>>(await consulta.ToListAsync());
                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
