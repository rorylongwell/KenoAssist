using Keno.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Keno.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public DbSet<TEntity> dbSet { get; set; }
        public KenoEntities context;
        public Repository(KenoEntities context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public Repository()
        {
            dbSet = context.Set<TEntity>();
        }

        public TEntity GetByID(object id)
        {
            var result = dbSet.Find(id);
            return result;
        }

        public List<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

        public TEntity Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
            context.SaveChanges();

            return entity;
        }

        public void AddRange(List<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }

        public TEntity Update(TEntity entity)
        {
            var type = entity.GetType().GetProperty("Id");
            object id = type.GetValue(entity, null);
            var local = dbSet.Find(id);

            context.Entry<TEntity>(local).State = EntityState.Detached;

            context.Entry<TEntity>(entity).State = EntityState.Modified;

            return entity;
        }

        public void Delete(object id)
        {
            var entity = GetByID(id);
            context.Entry<TEntity>(entity).State = EntityState.Modified;
        }

        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Count(filter);
        }
    }
}
