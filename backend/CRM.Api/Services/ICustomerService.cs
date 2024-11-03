using CRM.Api.DTOs;

namespace CRM.Api.Services;

public interface ICustomerService
{
    Task<CustomerGetResponse> GetCustomers(int pageNumber, int pageSize, string filter, string sort, string sortDirection);
    Task<CustomerDto> GetCustomerById(Guid id);
    Task<bool> CustomerExists(Guid customerId);
    Task UpdateCustomer(string pathCustomerId, CustomerDto customerDto);
}