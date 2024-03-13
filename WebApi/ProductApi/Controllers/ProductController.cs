using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductApi.Models;
using ProductApi.Repository;
using ProductApi.ViewModels;

namespace ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository; 
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        [HttpGet]
        public async Task<IActionResult> Get() 
        {
            var product= await _productRepository.GetAllProductAsync();
            return Ok(product);
        }
        [HttpPost]
        public async Task<IActionResult>Post([FromBody] AddProductViewModel addProductViewModel) 
        {
            if (ModelState.IsValid)
            {
                var product = new Product
                {
                    ProductName = addProductViewModel.ProductName,
                    ProductDescription = addProductViewModel.ProductDescription,
                };
                await _productRepository.AddProduct(product);
                return Ok("Added successfully");
            }
            return BadRequest(ModelState);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult>Get(int id)
        {
            var item=await _productRepository.GetAllById(id);
            return Ok(item);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id) 
        { 
            var result=await _productRepository.DeleteById(id);
            if(result==true)
            {
                return Ok("Deleted Successfully");
            }
            return Ok("No item found");

        }
        [HttpDelete]
        public async Task<IActionResult>DeleteAll()
        {
            var result= await _productRepository.DeleteAll();
            if(result==true) 
            {
                return Ok("Deleted Successfully");
            }
            return Ok("No Record Found");
        }
        [HttpPut("{id}")]
        public async Task<IActionResult>Update(int id,AddProductViewModel addProductViewModel)
        {
            var result=await _productRepository.UpdateProduct(id, addProductViewModel);
            if(result==true) 
            {
                return Ok("Updated Successfully");
            }
            return Ok("Not Found");
        }

    }
}
