using CRM.Api.Models;

namespace CRM.Api.Dao
{
    public interface ISalesOpportunityDao
    {
        Task<IEnumerable<SalesOpportunity>> GetSalesOpportunities(Guid customerId);
        Task UpdateSalesOpportunity(SalesOpportunity opportunity);
        Task<SalesOpportunity?> GetSalesOpportunityById(Guid id);
        Task CreateSalesOpportunity(SalesOpportunity opportunity);
    }
}