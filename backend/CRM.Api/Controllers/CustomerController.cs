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
        public ActionResult<CustomerDto> GetCustomer(Guid customerId)
        {
            try
            {
                var customer = _customerService.GetCustomerById(customerId);
                return Ok(customer);
            } catch (NotFoundException e)
            {
                _logger.LogError(e, "");
                return NotFound(new { Message = e.Message });
            } catch (BadRequestException e)
            {
                _logger.LogError(e, "");
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpGet]
        public ActionResult<CustomerGetResponse> GetCustomers(int pageNumber = 1, int pageSize = 10, CustomerFilter filter = null, string sort = "")
        {
            try
            {
                var customersResponse = _customerService.GetCustomers(pageNumber, pageSize, filter, sort);
                return Ok(customersResponse);
            } catch (NotFoundException e)
            {
                _logger.LogError(e, "");
                return NotFound(new { Message = e.Message });
            } catch (BadRequestException e)
            {
                _logger.LogError(e, "");
                return BadRequest(new { Message = e.Message });
            }
        }

        [HttpPut("{customerId}")]
        public ActionResult UpdateCustomer(string customerId, CustomerDto customerDto)
        {
            try
            {
                _customerService.UpdateCustomer(customerId, customerDto);
                return NoContent();
            } catch (NotFoundException e)
            {
                _logger.LogError(e, "");
                return NotFound(new { Message = e.Message });
            } catch (BadRequestException e)
            {
                _logger.LogError(e, "");
                return BadRequest(new { Message = e.Message });
            }
        }
    }
}