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
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService service)
        {
            _UserService = service;
        }

        [HttpPost("CreateUser")]
        public IActionResult CreateUser([FromBody] UserDTO user)
        {
            var newUser = new User()
            {
                UserName = user.UserName,
                Name = user.Name,
                Password = user.Password,
                UserType = "Client"
            };
            return StatusCode(StatusCodes.Status201Created, _UserService.CreateUser(newUser));
        }

        [Authorize]
        [HttpPut("UpdateUser")]
        public IActionResult UpdateUser([FromBody] UserDTO dto)
        {
            User userToUpdate = new User()
            {
                UserId = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value),
                //UserName = User.Claims.FirstOrDefault(c => c.Type.Contains("username")).Value,
                UserName = dto.UserName,
                Name = dto.Name,
                Password = dto.Password,
                UserType = "Client"
            };
            _UserService.UpdateUser(userToUpdate);
            return Ok("Usuario modificado exitosamente");
        }

        [Authorize]
        [HttpDelete]
        public IActionResult DeletemyAccount()
        {
            int id = int.Parse(User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier).Value);
            _UserService.DeleteUser(id);
            return NoContent();
        }
    }

}

