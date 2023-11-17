using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalTP.Data.Entities
{
	public class OrderLine
	{

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public int OrderId { get; set; }

        [ForeignKey("ProductId")]
        public int ProductId { get; set; }
        public int Quantity { get; set; }

        public virtual Product Product { get; set; }

        public int Amount { get; set; }
    }
}

