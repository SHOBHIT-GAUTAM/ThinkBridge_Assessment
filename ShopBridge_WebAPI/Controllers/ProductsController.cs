using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopBridge_WebAPI.Domain.Models;
using ShopBridge_WebAPI.Domain.Services.Interfaces;
using ShopBridge_WebAPI.Paging;

namespace ShopBridge_WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private IProductRepository _repo;
       

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        //Controller for Getting the list of all products
        //api/Products
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAllProducts([FromQuery] PagingParameters pagingParameters)
        {
            try
            {
                var products = await _repo.GetAllProductsAsync(pagingParameters);
                
                return Ok(products);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }

        //Controller for Getting the the product by ID
        //api/Products/{id}

        [HttpGet("{id}",Name ="ProductById")]
        public async Task<IActionResult> GetProductById(int id)
        {
            try
            {
                var product = await _repo.GetProductByIdAsync(id);
                if (product == null)
                {
                    
                    return NotFound();
                }
                else
                {
                   
                    return Ok(product);
                }
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }
        //Create product
        //api/Products
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] Product product)
        {
            try
            {
                if (!ModelState.IsValid)
                {

                    return BadRequest("Invalid model object");
                }
                if (product == null)
                {
                    
                    return BadRequest("product object is null");
                }
                


                
                  await _repo.CreateProduct(product);
                              
                return  CreatedAtRoute("ProductById", new { id = product.ProductId }, product);
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] Product product)
        {
            try
            {
                if (product == null)
                {
                    
                    return BadRequest("Product object is null");
                }
                if (!ModelState.IsValid)
                {
                    
                    return BadRequest("Invalid model object");
                }
                var productEntity = await _repo.GetProductByIdAsync(id);
                if (productEntity == null)
                {
                    
                    return NotFound();
                }

               await _repo.UpdateProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            try
            {
                var product = await _repo.GetProductByIdAsync(id);
                if (product == null)
                {
                   
                    return NotFound();
                }

                await _repo.DeleteProduct(product);
                return NoContent();
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
