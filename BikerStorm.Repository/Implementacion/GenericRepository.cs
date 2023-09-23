using BikerStorm.Repository.Contrato;
using BikerStorm.Repository.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BikerStorm.Repository.Implementacion
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {
        private readonly BikerStormContext _dbContext;
        public GenericRepository(BikerStormContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public IQueryable<TModel> Request(Expression<Func<TModel, bool>>? filter = null)
        {
            IQueryable<TModel> request = (filter == null) ? _dbContext.Set<TModel>() : _dbContext.Set<TModel>().Where(filter);
            return request;
        }
        public async Task<TModel> Create(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Add(model);
                await _dbContext.SaveChangesAsync();
                return model;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Edit(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Update(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
            
        }

        public async Task<bool> Delete(TModel model)
        {
            try
            {
                _dbContext.Set<TModel>().Remove(model);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
