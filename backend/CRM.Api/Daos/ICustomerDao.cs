using CRM.Api.DTOs;
using CRM.Api.Models;

namespace CRM.Api.Dao
{
    public interface ICustomerDao
    {
        Task<IEnumerable<Customer>> GetCustomers(int pageNumber, int pageSize, CustomerFilter filter, string sort, string sortDirection);
        Task<Customer?> GetCustomerById(Guid id);
        Task<int> GetTotalCount(CustomerFilter filter);
        Task<bool> CustomerExists(Guid customerId);
        Task UpdateCustomer(Customer customer);
    }
}