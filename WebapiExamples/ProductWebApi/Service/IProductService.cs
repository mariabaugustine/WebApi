using ProductWebApi.Models;

namespace ProductWebApi.Service
{
    public interface IProductService
    {
        void AddProduct(Product product);
        IEnumerable<Product> GetProducts(); 
        IEnumerable<Product> GetAllProductsByiD(int productIdd);
        public void delete();
        IEnumerable<Product>DeleteById(int productId);
        public void updateProduct(int  productId, Product product);
    }
}
