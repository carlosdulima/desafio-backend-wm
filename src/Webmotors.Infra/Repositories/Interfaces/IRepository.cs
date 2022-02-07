using System;
using System.Linq;
using System.Linq.Expressions;

namespace Webmotors.Infra.Repositories.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        void Delete(TEntity entity);
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        TEntity Get(object id);
        IQueryable<TEntity> GetAll();
        void Save();
        void Update(TEntity entity);
    }
}
