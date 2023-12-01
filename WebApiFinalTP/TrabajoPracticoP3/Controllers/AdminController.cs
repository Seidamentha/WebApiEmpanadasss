using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Security.Claims;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.Data.Models;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly IAdminServices _adminService;

        public AdminController(IAdminServices adminService)
        {
            _adminService = adminService;
        }

        private string GetRole()
        {
            return User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role)?.Value;
        }

        [HttpGet("GetProductId")]
        public IActionResult GetProductById(int productId)
        {
            string role = GetRole();
            if (role == "Admin")
            {
                Product prodId = _adminService.GetProductById(productId);
                return Ok(prodId);
            }
            return Forbid();
        }

        [HttpGet("GetAllProducts")]
        public IActionResult GetAllProduct()
        {
            string role = GetRole();
            if (role == "Admin")
            {
                var products = _adminService.GetAllProduct();
                return Ok(products ?? Enumerable.Empty<Product>());
            }
            return Forbid();
        }

        [HttpPost("NewClient")]
        public IActionResult AddProduct([FromBody] ProductPostDto dto)
        {
            string role = GetRole();
            if (role == "Admin")
            {
                var product = new Product
                {
                    Name = dto.Name,
                    Price = dto.Price,
                };
                int id = _adminService.AddProduct(product);
                return Ok(id);
            }
            return Forbid();
        }

        [HttpPut("UpdateProduct")]
        public IActionResult EditProduct(int productId, [FromBody] ProductUpdateDto updateProduct)
        {
            string role = GetRole();
            if (role == "Admin")
            {
                Product existingProduct = _adminService.GetProductById(productId);

                if (existingProduct != null)
                {
                    existingProduct.Name = updateProduct.Name;
                    existingProduct.Price = updateProduct.Price;

                    try
                    {
                        _adminService.EditProduct(existingProduct);
                        return Ok();
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
                    }
                }
                else
                {
                    return NotFound("Producto no encontrado");
                }
            }
            return Forbid();
        }

        [HttpDelete("DeleteProduct")]
        public IActionResult DeleteProduct(int productId)
        {
            string role = GetRole();
            if (role == "Admin")
            {
                Product productToDelete = _adminService.GetProductById(productId);

                if (productToDelete != null)
                {
                    try
                    {
                        _adminService.DeleteProduct(productToDelete);
                        return NoContent();
                    }
                    catch (Exception ex)
                    {
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error interno del servidor: {ex.Message}");
                    }
                }
                else
                {
                    return NotFound("Producto no encontrado");
                }
            }
            return Forbid();
        }


    }

}

