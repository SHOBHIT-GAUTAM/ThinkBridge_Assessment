using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopBridge_WebAPI.Data;
using ShopBridge_WebAPI.Data.Repository;
using ShopBridge_WebAPI.Domain.Models;
using ShopBridge_WebAPI.Domain.Services.Interfaces;
using ShopBridge_WebAPI.Paging;
using System.Linq.Expressions;

namespace ShopBridge_WebAPI.Domain.Services.Implementations
{
    public class ProductRepository : RepositoryBase<Product>, IProductRepository
    {
        public ShopBridge_Context _obj;
        public ProductRepository(ShopBridge_Context objContext):base(objContext)
        {
            _obj = objContext;


        }
        public async Task<Product> UpdateProduct(Product product)
        {
            _obj.Products.Update(product);
            await _obj.SaveChangesAsync();
            return product;
        }

        public async Task<Product> CreateProduct([FromBody] Product product)
        {
            _obj.Products.Add(product);
            await _obj.SaveChangesAsync();
            return product;

        }

        public async Task<Product> DeleteProduct(Product product)
        {
            _obj.Products.Remove(product);
            await _obj.SaveChangesAsync();
            return product;
        }

        /*public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await GetAll()
                   .OrderBy(productObj => productObj.ProductName)
                   .ToListAsync();
        } */

        public Task<PagedList<Product>> GetAllProductsAsync(PagingParameters pagingParameters)
        {
            return Task.FromResult(PagedList<Product>.GetPagedList(GetAll().OrderBy(s => s.ProductId), pagingParameters.PageNumber, pagingParameters.PageSize));
        }

        public async Task<Product> GetProductByIdAsync(int id)
        {
            return await GetById(product => product.ProductId.Equals(id)).FirstOrDefaultAsync();
        }

       

        
    }
}
