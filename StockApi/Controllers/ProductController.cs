using Microsoft.AspNetCore.Mvc;
using StockApi.Data.Model;
using StockApi.Data.Repository.Abstract;
using StockApi.Data.Repository.Concrete;

namespace StockApi.Controllers
{
    [Route("codebase/api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet("GetAll")]
        public async Task<JsonResult> GetAll()
        {
            var product = await _productRepository.GetAllAsync();
            return new JsonResult(product);
        }

        [HttpGet("GetBy{id:int}")]
        public  JsonResult GetById(int id)
        {
            var product =  _productRepository.GetByIdAsync(id);
            if(product.IsDeleted || product is null)
            {
                return new JsonResult("No record or deleted!");
            }

            return new JsonResult(product);

        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(string ProductName, double ProductPrice, int ProductCount)
        {

            Product product = new();
            product.ProductName = ProductName;
            product.ProductPrice = ProductPrice;
            product.ProductCount = ProductCount;
            product.CreatedAt = DateTime.UtcNow;

            await _productRepository.InsertAsync(product);

            return new JsonResult("Successful insert!");

        }

        [HttpDelete("Delete")]
        public void Delete(int id)
        {
            var product = _productRepository.GetByIdAsync(id);

            _productRepository.DeleteAsync(product);

        }

        [HttpPut("Update")]
        public JsonResult Update(int id,string ProductName, double ProductPrice, int ProductCount)
        {
            var product = _productRepository.GetByIdAsync(id);

            if (!product.IsDeleted)
            {
                if (ProductName != "")
                    product.ProductName = ProductName;
                if (ProductPrice != 0)
                    product.ProductPrice = ProductPrice;
                if (ProductCount != 0)
                    product.ProductCount = ProductCount;

                _productRepository.UpdateAsync(product);

                return new JsonResult(product);
            }

            return new JsonResult("No record or deleted!");

        }

    }
}
