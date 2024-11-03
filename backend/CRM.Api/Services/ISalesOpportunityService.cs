using CRM.Api.DTOs;

namespace CRM.Api.Services;

public interface ISalesOpportunityService
{
    Task<IEnumerable<SalesOpportunityDto>> GetSalesOpportunities(Guid customerId);
    Task<SalesOpportunityDto> GetSalesOpportunityById(Guid customerId);
    Task UpdateSalesOpportunity(string pathCustomerId, string pathOpportunityId, SalesOpportunityDto opportunityDto);
    Task CreateSalesOpportunity(string pathCustomerId, SalesOpportunityDto opportunityDto);
}