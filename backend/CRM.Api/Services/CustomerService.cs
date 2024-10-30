using CRM.Api.Dao;
using CRM.Api.DTOs;
using CRM.Api.Exceptions;
using CRM.Api.Models;

namespace CRM.Api.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerDao _customerDao;
        private readonly ILogger<CustomerService> _logger;
        public CustomerService(ICustomerDao customerDao, ILogger<CustomerService> logger)
        {
            _customerDao = customerDao;
            _logger = logger;
        }

        public IEnumerable<CustomerDto> GetCustomers(int pageNumber, int pageSize, string filter, string sort)
        {
            var customers = _customerDao.GetCustomers(pageNumber, pageSize, filter, sort);
            return customers.Select(c => new CustomerDto { Id = c.Id, Name = c.Name, Status = c.Status, CreatedAt = c.CreatedAt });
        }

        public CustomerDto GetCustomerById(Guid id)
        {
            var customer = _customerDao.GetCustomerById(id);
            if (customer == null)
            {
                throw new NotFoundException("customer not found for customer id = " + id);
            }
            return new CustomerDto
            {
                Id = customer.Id, 
                Name = customer.Name, 
                Status = customer.Status, 
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            };
        }

        public void UpdateCustomer(string pathCustomerId, CustomerDto customerDto)
        {
            var validationErrors = GetValidationErrors(customerDto);
            if (validationErrors.Count > 0)
            {
                throw new BadRequestException("Customer not valid: " + customerDto + string.Join(", ", validationErrors));
            }
            if (!Guid.TryParse(pathCustomerId, out var parsedPathCustomerId))
            {
                throw new BadRequestException("path customer id is invalid. pathCustomerId = " + pathCustomerId);
            }

            if (!parsedPathCustomerId.Equals(customerDto.Id))

            {
                throw new BadRequestException(
                    "path customer id or path opportunity id do not match the value in dto. pathCustomerId = " + 
                    pathCustomerId + " dto = " + 
                    customerDto
                );
            }
            
            var customer = _customerDao.GetCustomerById(customerDto.Id);
    
            if (customer == null)
            {
                throw new NotFoundException("customer not found: " + customerDto);
            }
            
            _customerDao.UpdateCustomer(new Customer
            {
                Id = Guid.NewGuid(),
                Name = customerDto.Name,
                Status = customerDto.Status,
                CreatedAt = customerDto.CreatedAt,
                UpdatedAt = DateTime.Now
            });
            
        }
        
        private static List<string> GetValidationErrors(CustomerDto customerDto)
        {
           var validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(customerDto.Name))
            {
                validationErrors.Add("Customer name cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(customerDto.Email) || !IsValidEmail(customerDto.Email))
            {
                validationErrors.Add("Invalid email address.");
            }

            if (string.IsNullOrWhiteSpace(customerDto.PhoneNumber))
            {
                validationErrors.Add("Phone number cannot be empty.");
            }

            if (string.IsNullOrWhiteSpace(customerDto.Status) || !IsValidStatus(customerDto.Status))
            {
                validationErrors.Add("Invalid status. Allowed values: Active, Non-Active, Lead.");
            }

            return validationErrors;
        }
        private static bool IsValidEmail(string email)
        {
            // Basic email validation logic
            return !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".");
        }

        private static bool IsValidStatus(string status)
        {
            // Validate if the status is one of the allowed values
            var validStatuses = new[] { "Active", "Non-Active", "Lead" };
            return validStatuses.Contains(status);
        }
    }
}
