using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccessLayer.Interfaces
{
    public interface IRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetQueryable();
        IEnumerable<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = "");
        TEntity GetByID(params object[] id);
        TEntity GetByID(object id);
        void Insert(TEntity entity);
        void Delete(object id);
        void InsertAll(IEnumerable<TEntity> entities);
        void DeleteAll(IEnumerable<TEntity> entities);
        void Delete(TEntity entityToDelete);
        void Update(TEntity entityToUpdate);
        void Upsert(TEntity entityToUpsert);
    }
}
