using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProductWebApi.Models;
using ProductWebApi.Service;
using ProductWebApi.ViewModel;

namespace ProductWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpPost]
        public IActionResult post([FromBody] AddProductViewModel addProductViewModel)
        {
            var product = new Product
            {
                ProductAmount = addProductViewModel.ProductAmount,
                ProductName = addProductViewModel.ProductName,
                ProductDescription = addProductViewModel.ProductDescription,
            };
            _productService.AddProduct(product);
            return Ok("Product added successfully");
        }
        [HttpGet]
        public IActionResult get()
        {
            var newList = _productService.GetProducts();
            if (newList.Count() == 0)
            {
                return Ok("no record Found");
            }
            return Ok(newList);
        }
        [HttpGet("{id}")]
        public IActionResult GetListById(int  id) 
        {
            var nlist = _productService.GetAllProductsByiD(id);
            if(nlist.Count()==0) 
            {
                return Ok("no record found");
            }
            return Ok(nlist);
            
            
        }
        [HttpDelete]
        public IActionResult Delete()
        {
            _productService.delete();
            return Ok("Deleted successfully");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(int id) 
        { 
            var item=_productService.DeleteById(id);
          
            
                return Ok("Item deleted");
            

        }
        [HttpPut("{id}")]
        public IActionResult Put([FromBody]Product product,int id) 
        { 
            _productService.updateProduct(id,product);
            return Ok("UPDATED");
        }

    }
}
