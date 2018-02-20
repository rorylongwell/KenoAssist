using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Keno.Data.Contracts
{
    public interface IRepository<TEntity> where TEntity : class
    {
        TEntity GetByID(object id);

        List<TEntity> GetAll();

        TEntity Add(TEntity entity);

        void AddRange(List<TEntity> entities);

        TEntity Update(TEntity entity);

        void Delete(object id);

        int Count(Expression<Func<TEntity, bool>> filter);
    }
}
