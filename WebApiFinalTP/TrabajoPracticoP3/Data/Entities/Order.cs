using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TPI_P3_grupal.Data.Enum;

namespace TrabajoPracticoP3.Data.Entities
{
    public class Order
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Payment { get; set; }
        public DateTime CreationDate { get; } = DateTime.Now.ToUniversalTime();
        public string? TotalPrize { get; set; }

        public OrderState State { get; set; } = OrderState.Pending;

        [ForeignKey("ClientId")]
        public Client? Client { get; set; }
        public int ClientId { get; set; }

        public List<SaleOrderLine> SaleOrderLine { get; set; } = new List<SaleOrderLine>();

    }

}