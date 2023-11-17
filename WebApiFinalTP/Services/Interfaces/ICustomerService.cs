using System;
namespace WebApiFinalTP.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer AddCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);
        // Otros métodos según sea necesario para la gestión de clientes
    }
}

