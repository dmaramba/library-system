using LibrarySystem.Models;

namespace LibrarySystem.Services
{
    public interface ICustomerService
    {
        public int AddCustoer(Customer customer);

        public List<Customer> GetCustomers();

        public Customer GetCustomerById(int id);
    }
}
