using System;
using WebApiFinalTP.Data;

namespace WebApiFinalTP.Services.Implementations
{
    public class CustomerService : ICustomerService
    {
        private readonly TPIContext _context;

        public CustomerService(TPIContext context)
        {
            _context = context;
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList();
        }

        public Customer? GetCustomerById(int id)
        {
            return _context.Customers.FirstOrDefault(c => c.UserId == id);
        }

        public Customer AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();

            return customer;
        }

        public void UpdateCustomer(Customer customer)
        {
            var existingCustomer = _context.Customers.FirstOrDefault(c => c.UserId == customer.UserId);

            if (existingCustomer != null)
            {
                existingCustomer.Name = customer.Name;
                existingCustomer.Email = customer.Email;
                // Actualizar otras propiedades según tu implementación

                _context.Update(existingCustomer);
                _context.SaveChanges();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var customerToDelete = _context.Customers.FirstOrDefault(c => c.UserId == customerId);

            if (customerToDelete != null)
            {
                _context.Customers.Remove(customerToDelete);
                _context.SaveChanges();
            }
        }
    }

}

