using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Sockets;
using System.Security.Claims;
using TrabajoPracticoP3.Data.Entities;
using TrabajoPracticoP3.Data.Models;
using TrabajoPracticoP3.Services.Implementations;
using TrabajoPracticoP3.Services.Interfaces;

namespace TrabajoPracticoP3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientServices _clientService;

        public ClientController(IClientServices clientService)
        {
            _clientService = clientService;
        }


        [HttpGet("GetClients")]
        public IActionResult GetClients()
        {
            string role = User.Claims.SingleOrDefault(c => c.Type.Contains("role")).Value;
            if (role == "Admin")
                return Ok(_clientService.GetClients());
            return Forbid();
        }


        [HttpPost("NewClient")]
        public IActionResult CreateClient([FromBody] ClientPostDto dto)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value.ToString();
            if (role == "Client")
            {
                var client = new Client()
                {
                    Name = dto.Name,
                    SurName = dto.SurName,
                    Email = dto.Email,
                    UserName = dto.UserName,
                    Password = dto.Password,
                    UserType = "Client",
                    Adress = dto.Adress,
                    PhoneNumber = dto.PhoneNumber
                };

                int id = _clientService.CreateClient(client);

                return Ok(id);
            }
            return Forbid();
        }


        [HttpPut("UpdateClient")]
        public IActionResult UpdateClient([FromBody] ClientUpdateDto updateClient)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            Client? uClient = null;

            if (role == "Client")
            {
                uClient = new Client()
                {
                    Id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                    Email = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Email).Value,
                    Name = updateClient.Name,
                    SurName = updateClient.SurName,
                    UserName = updateClient.UserName,
                    UserType = "Client",
                    Adress = updateClient.Adress,
                    PhoneNumber = updateClient.PhoneNumber,
                    Password = updateClient.Password
                };
            }

            _clientService.UpdateClient(uClient);

            return Ok();
        }


        [HttpDelete("DeleteClient")]
        public IActionResult DeleteUser(int UserId)
        {
            string role = User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.Role).Value;
            if (role == "Admin")
            {
                User userToDelete = _clientService.GetUserById(UserId);

                if (userToDelete != null)
                {
                    _clientService.DeleteUser(userToDelete);
                }
                else
                {
                    return NotFound("Usuario no encontrado");
                }
            }
            return NoContent();

        }

    }

}