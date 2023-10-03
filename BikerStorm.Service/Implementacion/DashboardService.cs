using AutoMapper;
using BikerStorm.DTO;
using BikerStorm.Model;
using BikerStorm.Repository.Contrato;
using BikerStorm.Service.Contrato;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.Service.Implementacion
{
    public class DashboardService : IDashboardService
    {
        private readonly IVentaRepository _ventaRepository;
        private readonly IGenericRepository<Usuario> _userRepository;
        private readonly IGenericRepository<Producto> _productRepository;

        public DashboardService
            (IVentaRepository ventaRepository,
            IGenericRepository<Usuario> userRepository,
            IGenericRepository<Producto> productRepository)
        {
            this._ventaRepository = ventaRepository;
            this._userRepository = userRepository;
            this._productRepository = productRepository;
        }

        public string Ingresos()
        {
            var consulta = _ventaRepository.Request();
            decimal? ingresos = consulta.Sum(x => x.Total);
            return Convert.ToString(ingresos);
        }

        public int Ventas()
        {
            var consulta = _ventaRepository.Request();
            int total = consulta.Count();
            return total;
        }

        public int Clientes()
        {
            var consulta = _userRepository.Request(u => u.IdRolNavigation.Descripcion.ToLower() == "cliente");
            int total = consulta.Count();
            return total;
        }

        public int Productos()
        {
            var consulta = _productRepository.Request();
            int total = consulta.Count();
            return total;
        }

        public DashboardDTO Resumen()
        {
            try
            {
                DashboardDTO dto = new DashboardDTO()
                {
                    TotalIngresos = Ingresos(),
                    TotalVentas = Ventas(),
                    TotalClientes = Clientes(),
                    TotalProductos = Productos(),
                };
                return dto;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
