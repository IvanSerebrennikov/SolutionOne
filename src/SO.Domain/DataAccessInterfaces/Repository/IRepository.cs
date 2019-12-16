using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SO.Domain.DataAccessInterfaces.Entity;

namespace SO.Domain.DataAccessInterfaces.Repository
{
    public interface IRepository<TEntity>
        where TEntity : class, IEntity
    {
        // TODO: Add GetCount, GetExists and etc methods

        TEntity GetById(int id);

        IReadOnlyList<TEntity> Get(
            Expression<Func<TEntity, bool>> filter = null,
            Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);

        IReadOnlyList<TProjection> GetProjections<TProjection>(
            Expression<Func<TEntity, TProjection>> projection,
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

        Task SaveAsync();
    }
}