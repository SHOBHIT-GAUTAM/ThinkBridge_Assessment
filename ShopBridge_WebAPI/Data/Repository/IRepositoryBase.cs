
using System.Linq.Expressions;

namespace ShopBridge_WebAPI.Data.Repository
{
    public interface IRepositoryBase <T>
    {
        IQueryable<T> GetAll ();
        IQueryable<T> GetById (Expression<Func<T,bool>> expression);
        void Create(T entity);

        void Update(T entity);

        void Delete(T entity);

    }
}
