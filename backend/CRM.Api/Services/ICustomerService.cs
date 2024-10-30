using CRM.Api.DTOs;

namespace CRM.Api.Services;

public interface ICustomerService
{
    IEnumerable<CustomerDto> GetCustomers(int pageNumber, int pageSize, string filter, string sort);
    CustomerDto GetCustomerById(Guid id);
    void UpdateCustomer(string pathCustomerId, CustomerDto customerDto);
}