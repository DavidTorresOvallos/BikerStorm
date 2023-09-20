using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.Repository.Contrato
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        IQueryable<TModel> Request (Expression<Func<TModel, bool>>? filter = null);
        Task<TModel> Create(TModel model);
        Task<bool> Edit(TModel model);
        Task<bool> Delete(TModel model);
    }
}
