using System.ComponentModel.DataAnnotations.Schema;
using TPI_P3_grupal.Data.Enum;
using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Data.Models
{
    public class OrderPostDto
    {
        public string? Payment { get; set; }
        public DateTime CreationDate { get; } = DateTime.Now.ToUniversalTime();
    }
}
