using ShopBridge_WebAPI.Data.Repository;
using ShopBridge_WebAPI.Domain.Models;
using ShopBridge_WebAPI.Paging;

namespace ShopBridge_WebAPI.Domain.Services.Interfaces
{
    public interface IProductRepository : IRepositoryBase<Product>
    { 
        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<Product> DeleteProduct(Product product);

        Task<PagedList<Product>> GetAllProductsAsync(PagingParameters pagingParameters);
        Task<Product> GetProductByIdAsync(int id);

    }
}

