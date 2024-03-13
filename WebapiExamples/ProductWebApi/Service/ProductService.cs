using ProductWebApi.Models;

namespace ProductWebApi.Service
{
    public class ProductService : IProductService
    {
        static List<Product> productList = new List<Product>();
        public void AddProduct(Product product)
        {
            product.ProductId = productList.Count == 0 ? 1 : productList.Max(x => x.ProductId) + 1;
            productList.Add(product);  
            
        }

        public void delete()
        {
           productList.Clear();
        }

        public IEnumerable<Product> DeleteById(int productId)
        {
            var find=productList.Find(x => x.ProductId == productId);
            if(find!=null) 
            {
                productList.Remove(find);
            }
            return productList;
        }

        public IEnumerable<Product> GetAllProductsByiD(int productIdd)
        {
            var pid = productList.FindAll(x => x.ProductId == productIdd);
            return pid;
        }

        public IEnumerable<Product> GetProducts()
        {
         return productList;
        }

        public void updateProduct(int productId, Product product)
        {
            var newList=productList.Find( x=>x.ProductId == productId);
            newList.ProductName=product.ProductName;
            newList.ProductDescription=product.ProductDescription;
            newList.ProductAmount=product.ProductAmount;
        }
    }
}
