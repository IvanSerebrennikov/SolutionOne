using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using SO.DataAccess.Interfaces.Entity;

namespace SO.DataAccess.Interfaces.Repository
{
    public interface IRepository<T>
        where T : IEntity
    {
        T GetById(int id);

        IReadOnlyList<T> Get(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string includeProperties = null,
            int? skip = null,
            int? take = null);

        void Create(T entity);

        void Update(T entity);

        void Delete(int id);
    }
}
