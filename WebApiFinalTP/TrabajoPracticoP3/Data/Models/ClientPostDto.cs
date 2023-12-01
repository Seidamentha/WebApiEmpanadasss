using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoP3.Data.Models
{
    public class ClientPostDto
    {
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Email { get; set; }
        public string? UserName { get; set; }
        public string? Password { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Adress { get; set;}
    }
}
