using CRM.Api.Models;

namespace CRM.Api.Dao
{
    public interface ICustomerDao
    {
        IEnumerable<Customer> GetCustomers(int pageNumber, int pageSize, string filter, string sort);
        Customer? GetCustomerById(Guid id);
        void UpdateCustomer(Customer customer);
    }
}