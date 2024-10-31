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

        public CustomerGetResponse GetCustomers(int pageNumber, int pageSize, CustomerFilter filter, string sort)
        {
            _logger.LogInformation("GetCustomers started with: pageNumber={PageNumber}, pageSize={PageSize}, filter={Filter}, sort={Sort}",
                pageNumber, pageSize, filter, sort);

            var validationErrors = GetCustomerValidationErrors(pageNumber, pageSize, filter, sort);
            if (validationErrors.Count > 0)
            {
                throw new BadRequestException("Invalid parameters: " + string.Join(", ", validationErrors));
            }

            var totalCount = _customerDao.GetTotalCount(filter);
            var customers = _customerDao.GetCustomers(pageNumber, pageSize, filter, sort);
    
            var customerDtos = customers.Select(c => new CustomerDto
            {
                Id = c.Id,
                Name = c.Name,
                Status = c.Status,
                Email = c.Email,
                PhoneNumber = c.PhoneNumber,
                CreatedAt = c.CreatedAt,
                UpdatedAt = c.UpdatedAt
            }).ToList();

            var response = new CustomerGetResponse
            {
                Data = customerDtos,
                Meta = new PaginationMeta()
                {
                    TotalCount = totalCount
                }
            };

            _logger.LogInformation("GetCustomers completed with result: {@Response}", response);
            return response;
        }

        private static List<string> GetCustomerValidationErrors(int pageNumber, int pageSize, CustomerFilter filter, string sort)
        {
            var validationErrors = new List<string>();

            if (pageNumber <= 0)
            {
                validationErrors.Add("Page number must be greater than 0.");
            }

            if (pageSize <= 0)
            {
                validationErrors.Add("Page size must be greater than 0.");
            }

            var validStatuses = new[] { "Active", "Non Active", "Lead" };
            if (filter.Status != null && !validStatuses.Contains(filter.Status))
            {
                validationErrors.Add("Invalid status value.");
            }

            var validSortValues = new[] { "name", "status" };
            if (!validSortValues.Contains(sort))
            {
                validationErrors.Add($"Invalid sort value. Allowed values: {string.Join(", ", validSortValues)}");
            }

            return validationErrors;
        }

        public CustomerDto GetCustomerById(Guid id)
        {
            _logger.LogInformation("GetCustomerById started with parameter: id={Id}", id);

            var customer = _customerDao.GetCustomerById(id);
            if (customer == null)
            {
                throw new NotFoundException("customer not found for customer id = " + id);
            }

            var customerDto = new CustomerDto
            {
                Id = customer.Id,
                Name = customer.Name,
                Status = customer.Status,
                Email = customer.Email,
                PhoneNumber = customer.PhoneNumber,
                CreatedAt = customer.CreatedAt,
                UpdatedAt = customer.UpdatedAt
            };

            _logger.LogInformation("GetCustomerById completed with result: {@CustomerDto}", customerDto);
            return customerDto;
        }

        public void UpdateCustomer(string pathCustomerId, CustomerDto customerDto)
        {
            _logger.LogInformation("UpdateCustomer started with: pathCustomerId={PathCustomerId}, customerDto={@CustomerDto}",
                pathCustomerId, customerDto);

            var validationErrors = GetValidationErrors(customerDto);
            if (validationErrors.Count > 0)
            {
                throw new BadRequestException("Customer not valid: " + string.Join(", ", validationErrors));
            }
            if (!Guid.TryParse(pathCustomerId, out var parsedPathCustomerId))
            {
                throw new BadRequestException("path customer id is invalid. pathCustomerId = " + pathCustomerId);
            }

            if (!parsedPathCustomerId.Equals(customerDto.Id))
            {
                throw new BadRequestException("path customer id or path opportunity id do not match the value in dto. pathCustomerId = " + pathCustomerId + " dto = " + customerDto);
            }

            var customer = _customerDao.GetCustomerById(customerDto.Id);
            if (customer == null)
            {
                throw new NotFoundException("customer not found: " + customerDto);
            }

            _customerDao.UpdateCustomer(new Customer
            {
                Id = customerDto.Id,
                Name = customerDto.Name,
                Status = customerDto.Status,
                Email = customerDto.Email,
                PhoneNumber = customerDto.PhoneNumber,
                CreatedAt = customerDto.CreatedAt,
                UpdatedAt = DateTime.UtcNow
            });

            _logger.LogInformation("UpdateCustomer completed successfully for customerId={CustomerId}", customerDto.Id);
        }

        private static List<string> GetValidationErrors(CustomerDto customerDto)
        {
            var validationErrors = new List<string>();

            if (string.IsNullOrWhiteSpace(customerDto.Name))
            {
                validationErrors.Add("Customer name cannot be empty");
            }

            if (string.IsNullOrWhiteSpace(customerDto.Email) || !IsValidEmail(customerDto.Email))
            {
                validationErrors.Add("Invalid email address");
            }

            if (string.IsNullOrWhiteSpace(customerDto.PhoneNumber))
            {
                validationErrors.Add("Phone number cannot be empty");
            }
            return validationErrors;
        }

        private static bool IsValidEmail(string email)
        {
            // Basic email validation logic
            return !string.IsNullOrWhiteSpace(email) && email.Contains("@") && email.Contains(".");
        }
    }
}