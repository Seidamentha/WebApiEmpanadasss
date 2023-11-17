using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiFinalTP.Data.Entities
{
	public class Order
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdOrderId{ get; set; }
        public bool Status { get; set; } = true;
        public DateTime OrderDate { get; set; }

        [ForeignKey("UserId")]
        public User User { get; set; }
        public int UserId { get; set; }

        public ICollection<OrderLine> OrderLines { get; set; } = new List<OrderLine>();

    }
}

