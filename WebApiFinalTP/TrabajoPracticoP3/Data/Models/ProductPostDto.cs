using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrabajoPracticoP3.Data.Models
{
    public class ProductPostDto
    {
        public string? Name { get; set; }
        public string? Price { get; set; }
    }
}
