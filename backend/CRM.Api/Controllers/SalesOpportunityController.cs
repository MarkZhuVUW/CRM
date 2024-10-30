using CRM.Api.DTOs;
using CRM.Api.Exceptions;
using CRM.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers;

[Route("api/customers/{customerId}/salesopportunities")]
[ApiController]
public class SalesOpportunityController : ControllerBase
{
    private readonly ISalesOpportunityService _salesOpportunityService;
    private readonly ILogger<SalesOpportunityController> _logger;
    public SalesOpportunityController(ISalesOpportunityService salesOpportunityService, ILogger<SalesOpportunityController> logger)
    {
        _salesOpportunityService = salesOpportunityService;
        _logger = logger;
    }

    [HttpGet]
    public ActionResult<IEnumerable<SalesOpportunityDto>> GetSalesOpportunities(Guid customerId)
    {
        try
        {
            var opportunities = _salesOpportunityService.GetSalesOpportunities(customerId);
            return Ok(opportunities);
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

    [HttpPut("{opportunityId}")]
    public ActionResult UpdateSalesOpportunity(string customerId, string opportunityId, SalesOpportunityDto opportunityDto)
    {
        try
        {
            _salesOpportunityService.UpdateSalesOpportunity(customerId, opportunityId, opportunityDto);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            _logger.LogError(e, "");
            return NotFound(new { Message = e.Message });
        }
        catch (BadRequestException e)
        {
            _logger.LogError(e, "");
            return BadRequest(new { Message = e.Message });
        }
    }
}