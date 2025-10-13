using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly LibraryDBContext _context;
        public CustomerService(LibraryDBContext context)
        {
            this._context = context;
        }

        public int AddCustoer(Customer customer)
        {
           _context.Customers.Add(customer);
            return customer.Id;
        }

        public Customer GetCustomerById(int id)
        {
            var customer = _context.Customers.FirstOrDefault(x => x.Id == id);
            return customer!;
        }

        public List<Customer> GetCustomers()
        {
           return _context.Customers.ToList();
        }
    }
}
