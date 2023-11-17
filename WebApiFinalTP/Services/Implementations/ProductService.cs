using System;
using WebApiFinalTP.Data;
using WebApiFinalTP.Data.Models;

namespace WebApiFinalTP.Services.Implementations
{
    public class ProductService : IProductService
    {
        private readonly TPIContext _context;

        public ProductService(TPIContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.ToList();
        }

        public Product? GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(x => x.ProductId == id);
        }

        public Product AddProduct(ProductDto productDto)
        {
            var product = new Product
            {
                Description = productDto.Description,
                Status = productDto.Status,
                Price = productDto.Price
            };

            _context.Products.Add(product);
            _context.SaveChanges();

            return product;
        }

        public void DeleteProduct(int productId)
        {
            Product productToBeRemoved = _context.Products.FirstOrDefault(p => p.ProductId == productId);
            productToBeRemoved.Status = false;
            _context.Update(productToBeRemoved);
            _context.SaveChanges();
        }

        public void UpdateProductStatusById(int id)
        {
            Product productToBeEnabled = _context.Products.FirstOrDefault(p => p.ProductId == id);
            productToBeEnabled.Status = true;
            _context.Update(productToBeEnabled);
            _context.SaveChanges();
        }

        public void EditProductById(int id, ProductDto productDto)
        {
            var productToEdit = _context.Products.FirstOrDefault(p => p.ProductId == id);

            if (productToEdit != null)
            {
                productToEdit.Description = productDto.Description;
                productToEdit.Status = productDto.Status;
                productToEdit.Price = productDto.Price;

                _context.Update(productToEdit);
                _context.SaveChanges();
            }
        }
    }

}

