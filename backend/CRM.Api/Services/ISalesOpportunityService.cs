using CRM.Api.DTOs;

namespace CRM.Api.Services;

public interface ISalesOpportunityService
{
    IEnumerable<SalesOpportunityDto> GetSalesOpportunities(Guid customerId);
    void UpdateSalesOpportunity(string pathCustomerId, string pathOpportunityId, SalesOpportunityDto opportunityDto);
}