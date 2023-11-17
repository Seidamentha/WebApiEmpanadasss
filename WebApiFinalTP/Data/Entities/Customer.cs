using System;
namespace WebApiFinalTP.Data.Entities
{
    public class Customer : User
    {
        public ICollection<Order> Orders { get; set; } = new List<Order>();


        // Constructor para inicializar la lista de pedidos
        public Customer()
        {
            Orders = new List<Order>();
        }
    }

}

