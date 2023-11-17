using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiFinalTP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private readonly TPIContext _context;

        public ProductController(IProductService productService, TPIContext context)
        {
            _productService = productService;
            _context = context;
        }

        [HttpGet("GetProducts")]
        public IActionResult GetProducts()
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Client" || role == "Admin")
            {
                var productList = _productService.GetProducts().Where(p => p.Status != false).ToList();
                return Ok(productList);
            }
            return Forbid();
        }

        [HttpGet("GetProductsId/{id}")]
        public IActionResult GetProductsId(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Client" || role == "Admin")
            {
                var productToGet = _context.Products.FirstOrDefault(p => p.ProductId == id);
                if (productToGet == null)
                {
                    return NotFound($"El producto de ID {id} no se ha encontrado.");
                }
                return Ok(_productService.GetProductById(id));
            }
            return Forbid();
        }

        [HttpPost("AddProduct")]
        public IActionResult AddProduct([FromBody] ProductDto productDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")
            {
                // Lógica para agregar productos de empanadas
                // ...

                var addedProduct = _productService.AddProduct(productDto);
                return CreatedAtAction("AddProduct", new { id = addedProduct.ProductId }, addedProduct);
            }
            return Forbid();
        }

        [HttpDelete("DeleteProductById/{id}")]
        public IActionResult DeleteProductById(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")
            {
                // Lógica para eliminar productos de empanadas
                // ...

                _productService.DeleteProduct(id);
                return Ok($"El producto con el ID: {id} se ha eliminado correctamente");
            }
            return Forbid();
        }

        [HttpPut("UpdateProductStatusById/{id}")]
        public IActionResult UpdateProductStatusById(int id)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")
            {
                // Lógica para actualizar el estado de productos de empanadas
                // ...

                _productService.UpdateProductStatusById(id);
                return Ok($"El producto con el ID: {id} se ha dado de alta nuevamente");
            }
            return Forbid();
        }

        [HttpPut("EditProductById/{id}")]
        public IActionResult EditProductById(int id, [FromBody] ProductToEditDto productToEditDto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")
            {
                // Lógica para editar productos de empanadas
                // ...

                _context.SaveChanges();
                return Ok($"El producto con el ID: {id} se ha actualizado correctamente.");
            }
            return Forbid();
        }
    }

    // El código de la tienda de empanadas que proporcioné anteriormente
    [Route("api/[controller]")]
    [ApiController]
    public class EmpanadaController : ControllerBase
    {
        // ...
    }
}

