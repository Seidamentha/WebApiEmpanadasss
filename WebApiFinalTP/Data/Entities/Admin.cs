using System;
namespace WebApiFinalTP.Data.Entities
{
        public class Admin : User
        {
            public string Position { get; set; } // Cargo del administrador de ventas

            // Catálogo de empanadas disponibles para la venta
            public List<Empanada> EmpanadaCatalog { get; set; } = new List<Empanada>();

            // Lista de clientes registrados
            public List<Customer> Customers { get; set; } = new List<Customer>();

            // Lista de administradores
            public List<Admin> OtherAdmins { get; set; } = new List<Admin>();

            // Método para agregar una nueva empanada al catálogo
            public void AddEmpanada(Empanada newEmpanada)
            {
                EmpanadaCatalog.Add(newEmpanada);
            }

            // Método para modificar el precio de una empanada
            public void UpdateEmpanadaPrice(int empanadaId, decimal newPrice)
            {
                var empanadaToUpdate = EmpanadaCatalog.FirstOrDefault(e => e.EmpanadaId == empanadaId);
                if (empanadaToUpdate != null)
                {
                    empanadaToUpdate.Price = newPrice;
                }
            }

            // Método para sacar una empanada de la venta (por ejemplo, si no hay stock)
            public void RemoveEmpanadaFromSale(int empanadaId)
            {
                var empanadaToRemove = EmpanadaCatalog.FirstOrDefault(e => e.EmpanadaId == empanadaId);
                if (empanadaToRemove != null)
                {
                    EmpanadaCatalog.Remove(empanadaToRemove);
                }
            }

            // Método para dar de alta a un nuevo cliente
            public void RegisterCustomer(Customer newCustomer)
            {
                Customers.Add(newCustomer);
            }

            // Método para modificar información de un cliente
            public void UpdateCustomerInfo(int customerId, string newName, string newUserName)
            {
                var customerToUpdate = Customers.FirstOrDefault(c => c.UserId == customerId);
                if (customerToUpdate != null)
                {
                    customerToUpdate.Name = newName;
                    customerToUpdate.UserName = newUserName;
                }
            }

            // Método para dar de alta a otro administrador
            public void RegisterAdmin(Admin newAdmin)
            {
                OtherAdmins.Add(newAdmin);
            }

           
        }

    
}

