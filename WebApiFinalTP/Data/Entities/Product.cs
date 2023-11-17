using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace WebApiFinalTP.Data.Entities
{
	public class Product
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ProductId { get; set; }

        public string? Description { get; set; } // Uso de tipo nullable para permitir valores nulos
        public decimal Price { get; set; }
        public bool Status { get; set; }

        
    }
}

