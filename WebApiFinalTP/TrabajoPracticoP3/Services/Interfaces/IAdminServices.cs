using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Services.Interfaces
{
    public interface IAdminServices
    {
        public int AddProduct(Product product);
        public void DeleteProduct(Product product);
        public void EditProduct(Product product);
        public Product GetProductById (int productId);
        public List<Product> GetAllProduct();
        public void HighLogicProduct(Product product);
        public void DeleteLogicProduct(Product product);
    }
}
