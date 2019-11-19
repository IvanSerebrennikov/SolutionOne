using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Interfaces.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        TEntity GetById(int id);

        IReadOnlyList<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);

        void Create(TEntity entity);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        void Delete(int id);

        void Save();
    }
}