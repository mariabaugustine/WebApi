using ProductApi.Models;
using ProductApi.ViewModels;

namespace ProductApi.Repository
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllProductAsync();
        Task<Product>AddProduct(Product product);
        Task<Product>GetAllById(int id);
        Task<bool>DeleteById(int id);
        Task<bool> DeleteAll();
        Task<bool> UpdateProduct(int id, AddProductViewModel addProductViewModel);

     }
}
