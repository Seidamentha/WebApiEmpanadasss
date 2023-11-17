using System;
using WebApiFinalTP.Data.Models;

namespace WebApiFinalTP.Services.Interfaces
{
    public interface IProductService
    {
        List<Product> GetProducts();
        Product? GetProductById(int id);
        Product AddProduct(ProductDto productDto);
        void DeleteProduct(int productId);
        void UpdateProductStatusById(int id);
        void EditProductById(int id);
        
    }
}

