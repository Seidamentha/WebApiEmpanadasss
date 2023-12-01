using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TrabajoPracticoP3.Data.Entities;

namespace TrabajoPracticoP3.Data.Models
{
    public class SaleOrderLinePostDto
    {
        public int ProductId { get; set; }
        public int ProductQuntity { get; set; }
    }
}
