using CRM.Api.DTOs;

namespace CRM.Api.Services;

public interface ICustomerService
{
    CustomerGetResponse GetCustomers(int pageNumber, int pageSize, CustomerFilter filter, string sort);
    CustomerDto GetCustomerById(Guid id);
    void UpdateCustomer(string pathCustomerId, CustomerDto customerDto);
}