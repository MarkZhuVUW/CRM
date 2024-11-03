using CRM.Api.DTOs;
using CRM.Api.Exceptions;
using CRM.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers
{
    [Route("api/customers")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        private readonly ILogger<CustomerController> _logger;

        public CustomerController(ICustomerService customerService, ILogger<CustomerController> logger)
        {
            _customerService = customerService;
            _logger = logger;
        }

        [HttpGet("{customerId}")]
        public async Task<ActionResult<CustomerDto>> GetCustomer(Guid customerId)
        {
            try
            {
                var customer = await _customerService.GetCustomerById(customerId);
                return Ok(customer);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, "Customer with ID {CustomerId} not found", customerId);
                return NotFound(new { Message = e.Message });
            }
            catch (BadRequestException e)
            {
                _logger.LogError(e, "Bad request for Customer ID {CustomerId}", customerId);
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpGet]
        public async Task<ActionResult<CustomerGetResponse>> GetCustomers(
            int pageNumber = 1, int pageSize = 10, string filter = "", string sort = "", string sortDirection = "asc")
        {
            try
            {
                var customersResponse = await _customerService.GetCustomers(pageNumber, pageSize, filter, sort, sortDirection);
                return Ok(customersResponse);
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, "Customers not found with pageNumber: {PageNumber}, pageSize: {PageSize}, filter: {Filter}, sort: {Sort} sortDirection: {SortDirection}",
                    pageNumber, pageSize, filter, sort, sortDirection);
                return NotFound(new { Message = e.Message });
            }
            catch (BadRequestException e)
            {
                _logger.LogError(e, "Bad request for customers with pageNumber: {PageNumber}, pageSize: {PageSize}, filter: {Filter}, sort: {Sort} sortDirection: {SortDirection}",
                    pageNumber, pageSize, filter, sort, sortDirection);
                return BadRequest(new { Message = e.Message });
            }
        }
        
        [HttpPatch("{customerId}")]
        public async Task<ActionResult> UpdateCustomer(string customerId, [FromBody] CustomerPatchRequest requestBody)
        {
           
            try
            {
                await _customerService.UpdateCustomer(customerId, new CustomerDto
                {
                    Name = string.IsNullOrWhiteSpace(requestBody.Name) ? "" : requestBody.Name,
                    Status = string.IsNullOrWhiteSpace(requestBody.Status) ? "" : requestBody.Status,
                    PhoneNumber = string.IsNullOrWhiteSpace(requestBody.PhoneNumber) ? "" : requestBody.PhoneNumber
                });
                return NoContent();
            }
            catch (NotFoundException e)
            {
                _logger.LogError(e, "Customer with ID {CustomerId} not found", customerId);
                return NotFound(new { Message = e.Message });
            }
            catch (BadRequestException e)
            {
                _logger.LogError(e, "Invalid patch request for Customer ID {CustomerId}", customerId);
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}