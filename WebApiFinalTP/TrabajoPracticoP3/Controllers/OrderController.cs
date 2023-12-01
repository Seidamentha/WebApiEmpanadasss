using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TPI_P3_grupal.Data.Enum;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.Data.Models;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class OrderController : ControllerBase
    {
        private readonly IOrderServices _orderService;

        public OrderController(IOrderServices orderService)
        {
            _orderService = orderService;
        }


        [HttpGet("{id}")]
        public IActionResult GetOrder([FromRoute] int id)
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "Admin")
            {
                var order = _orderService.GetOrder(id);
                if (order != null)
                {
                    return Ok(order);
                }
                return NotFound();
            }
            return Forbid();
        }


        [HttpPost]
        public IActionResult AddOrder([FromBody] OrderPostDto orderPostdto)
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "Client")
            {
                Order order = new()
                {
                    ClientId = int.Parse(User.Claims.SingleOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Payment = orderPostdto.Payment,
                    State = OrderState.Pending
                };

                _orderService.AddOrder(order);
             
                return Ok(order);
            }
          
            return Forbid();
        }

    }
}
