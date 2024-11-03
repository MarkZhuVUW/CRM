using CRM.Api.Dao;
using CRM.Api.DTOs;
using CRM.Api.Exceptions;

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

        public async Task<CustomerGetResponse> GetCustomers(int pageNumber, int pageSize, string filter, string sort, string sortDirection)
        {
            _logger.LogInformation("GetCustomers started with: pageNumber={PageNumber}, pageSize={PageSize}, filter={Filter}, sort={Sort}, sortDirection={SortDirection}",
                pageNumber, pageSize, filter, sort, sortDirection);

            var customerFilter = ParseFilter(filter);

            var validationErrors = GetCustomerValidationErrors(pageNumber, pageSize, customerFilter, sort, sortDirection);
            if (validationErrors.Count > 0)
            {
                throw new BadRequestException("Invalid parameters: " + string.Join(", ", validationErrors));
            }

            var totalCount = await _customerDao.GetTotalCount(customerFilter);
            var customers = await _customerDao.GetCustomers(pageNumber, pageSize, customerFilter, sort, sortDirection);

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

        private static CustomerFilter ParseFilter(string filter)
        {
            var customerFilter = new CustomerFilter();
            var splitFilter = filter.Split(",", StringSplitOptions.RemoveEmptyEntries);

            foreach (var part in splitFilter)
            {
                var keyValue = part.Split("=", StringSplitOptions.RemoveEmptyEntries);
                var key = keyValue[0];
                var value = keyValue[1];

                if (key == "name")
                {
                    customerFilter.Name = value;
                }
                else if (key == "status")
                {
                    customerFilter.Status = value;
                }
                else
                {
                    throw new BadRequestException("Invalid filter = " + filter);
                }
            }

            return customerFilter;
        }

        private static List<string> GetCustomerValidationErrors(int pageNumber, int pageSize, CustomerFilter filter, string sort, string sortDirection)
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

            var validStatuses = new[] { "Active", "Non-Active", "Lead" };
            if (filter.Status != null && !validStatuses.Contains(filter.Status))
            {
                validationErrors.Add("Invalid status value.");
            }

            var validSortValues = new[] { "name", "status", "" };
            if (!validSortValues.Contains(sort))
            {
                validationErrors.Add($"Invalid sort value. Allowed values: {string.Join(", ", validSortValues)}");
            }

            var validSortDirections = new[] { "asc", "desc" };
            if (!validSortDirections.Contains(sortDirection))
            {
                validationErrors.Add($"Invalid sort direction. Allowed values: {string.Join(", ", validSortDirections)}");
            }

            return validationErrors;
        }

        public async Task<CustomerDto> GetCustomerById(Guid id)
        {
            _logger.LogInformation("GetCustomerById started with parameter: id={Id}", id);

            var customer = await _customerDao.GetCustomerById(id);
            if (customer == null)
            {
                throw new NotFoundException("Customer not found for customer id = " + id);
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
        public async Task<bool> CustomerExists(Guid customerId)
        {
            try
            {
                await GetCustomerById(customerId);
                return true;
            }
            catch (NotFoundException e)
            {
                return false;
            }
        }
        
        public async Task UpdateCustomer(string pathCustomerId, CustomerDto customerDto)
        {
            _logger.LogInformation("UpdateCustomer started with: pathCustomerId={PathCustomerId}, customerDto={@CustomerDto}",
                pathCustomerId, customerDto);
            
            if (!Guid.TryParse(pathCustomerId, out var parsedPathCustomerId))
            {
                throw new BadRequestException("path customer id is invalid. pathCustomerId = " + pathCustomerId);
            }
            
            var validStatuses = new[] { "Active", "Non-Active", "Lead" };
            if (!string.IsNullOrWhiteSpace(customerDto.Status) && !validStatuses.Contains(customerDto.Status))
            {
                throw new BadRequestException("Invalid status provided. pathCustomerId = " + pathCustomerId + " status=" + customerDto.Status);
            }
            
            

            var customer = await _customerDao.GetCustomerById(parsedPathCustomerId);
            if (customer == null)
            {
                throw new NotFoundException("Customer not found for customerId: " + pathCustomerId);
            }
            
            customer.Name = string.IsNullOrWhiteSpace(customerDto.Name) ? customer.Name : customerDto.Name;
            customer.Status = string.IsNullOrWhiteSpace(customerDto.Status) ? customer.Status : customerDto.Status;
            customer.Email = string.IsNullOrWhiteSpace(customerDto.Email) ? customer.Email : customerDto.Email;
            customer.PhoneNumber = string.IsNullOrWhiteSpace(customerDto.PhoneNumber) ? customer.PhoneNumber : customerDto.PhoneNumber;

            customer.UpdatedAt = DateTime.UtcNow;
            
            await _customerDao.UpdateCustomer(customer);

            _logger.LogInformation("UpdateCustomer completed successfully for customerId={CustomerId}", pathCustomerId);
        }
    }
    
    
}