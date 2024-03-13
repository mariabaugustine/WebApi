using Microsoft.EntityFrameworkCore;
using ProductApi.DBContext;
using ProductApi.Models;
using ProductApi.ViewModels;

namespace ProductApi.Repository
{
    public class ProductRepository : IProductRepository
    { 
        private readonly ProductDBContext _context;
        public ProductRepository(ProductDBContext context) 
        {
            _context = context;
        }

        public async Task<Product> AddProduct(Product product)
        {
           await _context.Products.AddAsync(product);
           await _context.SaveChangesAsync();
            return product;
        }

        public async Task<bool> DeleteAll()
        {
            if(_context.Products.ToList().Count != 0)
            {
                await _context.Products.ExecuteDeleteAsync();
                _context.SaveChangesAsync();
                return true;
            }
            return false;
        }

        public async Task<bool> DeleteById(int id)
        {
            //var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id == id);
            var product = await GetAllById(id);
            if (product != null) 
            { 
                _context.Products.Remove(product);
                await _context.SaveChangesAsync();
                return true;
            }
            return false;

            
        }
        
        public  async Task<Product>GetAllById(int productId)
        {
           
            return await _context.Products.FirstOrDefaultAsync(x=>x.Id==productId);   
            
        }

        public  async Task<IEnumerable<Product>> GetAllProductAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<bool> UpdateProduct(int id, AddProductViewModel addProductViewModel)
        {
            var result=await _context.Products.FirstOrDefaultAsync(x=>x.Id==id);
            if (result!=null) 
            {

                result.ProductName = addProductViewModel.ProductName;
                result.ProductDescription = addProductViewModel.ProductDescription;
                _context.SaveChangesAsync();
                return true;
            }
            return false;    
         }
      }
 }

