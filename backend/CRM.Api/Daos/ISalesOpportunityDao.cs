using CRM.Api.Models;

namespace CRM.Api.Dao
{
    public interface ISalesOpportunityDao
    {
        IEnumerable<SalesOpportunity> GetSalesOpportunities(Guid customerId);
        void UpdateSalesOpportunity(SalesOpportunity opportunity);
        SalesOpportunity? GetSalesOpportunityById(Guid id);
    }
}