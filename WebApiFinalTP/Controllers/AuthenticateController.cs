using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApiFinalTP.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        public IAdminService _adminService;
        public readonly IUserService _userService;
        public IConfiguration _config;

        public AuthenticateController(IAdminService adminService, IConfiguration configuration, IUserService userService)
        {
            _adminService = adminService;
            _config = configuration;
            _userService = userService;
        }
        // el usuario primero debe validar su usuario (userService) y luego se le retorna su token
        [HttpPost]
        public IActionResult Authenticate([FromBody] CredentialsDto credentialsDto)
        {
            //valido usuario
            UserResponse validarUsuarioResult = _userService.ValidateUser(credentialsDto.UserName, credentialsDto.Password);
            if (validarUsuarioResult.Message == "Wrong Username")
            {
                return BadRequest(validarUsuarioResult.Message);
            }
            else if (validarUsuarioResult.Message == "Wrong Password")
            {
                return Unauthorized();
            }
            if (validarUsuarioResult.Result)
            {
                //generacion del token
                User user = _userService.GetUserByUsername(credentialsDto.UserName);
                //Paso 2: Crear el token
                var securityPassword = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_config["Authentication:SecretForKey"])); //Traemos la SecretKey del Json. agregar antes: using Microsoft.IdentityModel.Tokens;

                var signature = new SigningCredentials(securityPassword, SecurityAlgorithms.HmacSha256);

                //Los claims son datos en clave->valor que nos permite guardar data del usuario.
                var claimsForToken = new List<Claim>();
                claimsForToken.Add(new Claim("sub", user.UserId.ToString())); //"sub" es una key estándar que significa unique user identifier, es decir, si mandamos el id del usuario por convención lo hacemos con la key "sub".
                claimsForToken.Add(new Claim("username", user.UserName));
                claimsForToken.Add(new Claim("role", user.UserType)); //Debería venir del usuario

                var jwtSecurityToken = new JwtSecurityToken( //agregar using System.IdentityModel.Tokens.Jwt; Acá es donde se crea el token con toda la data que le pasamos antes.
                    _config["Authentication:Issuer"],
                    _config["Authentication:Audience"],
                    claimsForToken,
                    DateTime.UtcNow,
                    DateTime.UtcNow.AddHours(1),
                    signature);

                string tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
                return Ok(tokenToReturn);
            }
            return BadRequest();
        }
    }
}

