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

    [HttpPost]
    public async Task<IActionResult> CreateSalesOpportunity(string customerId, SalesOpportunityDto opportunityDto)
    {
        _logger.LogInformation("CreateSalesOpportunity endpoint called with: {@OpportunityDto}", opportunityDto);

        try
        {
            await _salesOpportunityService.CreateSalesOpportunity(customerId, opportunityDto);
            return Created();
        }
        catch (BadRequestException ex)
        {
            _logger.LogWarning(ex, "Bad request while creating Sales Opportunity.");
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unexpected error occurred while creating Sales Opportunity.");
            return StatusCode(500, "Internal server error");
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<SalesOpportunityGetResponse>> GetSalesOpportunities(Guid customerId)
    {
        try
        {
            var opportunities = await _salesOpportunityService.GetSalesOpportunities(customerId);
            return Ok(new SalesOpportunityGetResponse
            {
                Data = opportunities
            });
        }
        catch (NotFoundException e)
        {
            _logger.LogError(e, "Sales opportunities not found for Customer ID: {CustomerId}", customerId);
            return NotFound(new { Message = e.Message });
        }
        catch (BadRequestException e)
        {
            _logger.LogError(e, "Bad request for retrieving sales opportunities for Customer ID: {CustomerId}", customerId);
            return BadRequest(new { Message = e.Message });
        }
    }

    [HttpPut("{opportunityId}")]
    public async Task<ActionResult> UpdateSalesOpportunity(string customerId, string opportunityId, SalesOpportunityDto opportunityDto)
    {
        try
        {
            await _salesOpportunityService.UpdateSalesOpportunity(customerId, opportunityId, opportunityDto);
            return NoContent();
        }
        catch (NotFoundException e)
        {
            _logger.LogError(e, "Sales opportunity not found for Customer ID: {CustomerId}, Opportunity ID: {OpportunityId}", customerId, opportunityId);
            return NotFound(new { Message = e.Message });
        }
        catch (BadRequestException e)
        {
            _logger.LogError(e, "Bad request for updating sales opportunity with Customer ID: {CustomerId}, Opportunity ID: {OpportunityId}. Opportunity DTO: {@OpportunityDto}", 
                customerId, opportunityId, opportunityDto);
            return BadRequest(new { Message = e.Message });
        }
    }
}