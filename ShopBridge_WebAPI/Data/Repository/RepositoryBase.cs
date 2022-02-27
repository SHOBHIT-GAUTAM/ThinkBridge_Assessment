using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace ShopBridge_WebAPI.Data.Repository
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T: class
    {
        public ShopBridge_Context RepositoryContext { get; set; }
        public RepositoryBase(ShopBridge_Context _RepositoryContext)
        {
            RepositoryContext = _RepositoryContext;
        }
        public IQueryable<T> GetAll()
        {
            return RepositoryContext.Set<T>().AsNoTracking();
        }
        public IQueryable<T> GetById(Expression<Func<T, bool>> expression)
        {
            return RepositoryContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Update(T entity)
        {
            RepositoryContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            RepositoryContext.Set<T>().Remove(entity);
        }

        public void Create(T entity)
        {
            RepositoryContext.Set<T>().Add(entity);
        }

    }

    
}
