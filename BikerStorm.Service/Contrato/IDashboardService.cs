using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BikerStorm.DTO;

namespace BikerStorm.Service.Contrato
{
    public interface IDashboardService
    {
        DashboardDTO Resumen();
    }
}
