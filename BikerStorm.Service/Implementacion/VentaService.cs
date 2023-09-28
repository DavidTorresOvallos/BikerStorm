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
    public class VentaService : IVentaService
    {
        private readonly IVentaRepository _modelRepository;
        private readonly IMapper _mapper;

        public VentaService(IVentaRepository modelRepository, IMapper mapper)
        {
            this._modelRepository = modelRepository;
            this._mapper = mapper;
        }

        public async Task<VentaDTO> RegisterSale(VentaDTO model)
        {
            try
            {
                var dbModel = _mapper.Map<Venta>(model);
                var saleGenerated = _modelRepository.Register(dbModel);

                if (saleGenerated.Id == 0)
                {
                    throw new TaskCanceledException("No se pudo registrar la venta");
                }
                return _mapper.Map<VentaDTO>(saleGenerated);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
