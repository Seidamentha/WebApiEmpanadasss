using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.DBContext;
using TrabajoPracticoP3.Services.Interfaces;
using static TrabajoPracticoP3.Services.Implementations.AdminServices;

namespace TrabajoPracticoP3.Services.Implementations
{
    public class AdminServices : IAdminServices
    {

        private readonly ECommerceContext _context;

        public AdminServices(ECommerceContext context)
        {
         _context = context;
        }

        public int AddProduct(Product product)
        {
            _context.Add(product);
            _context.SaveChanges();
            return product.Id;
        }

        public void DeleteProduct(Product Product)
        {
            _context.Remove(Product);
            _context.SaveChanges();
        }

        public Product GetProductById(int productId)
        {
            return _context.Products.FirstOrDefault(p => p.Id == productId);
        }

        public List<Product> GetAllProduct() => _context.Products.ToList();

        public void EditProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public void HighLogicProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }

        public void DeleteLogicProduct(Product product)
        {
            _context.Update(product);
            _context.SaveChanges();
        }
    }
}
