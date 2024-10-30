using CRM.Api.Models;
using CRM.Api.Context;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Dao
{
    public class SalesOpportunityDao : ISalesOpportunityDao
    {
        private readonly CrmDbContext _context;

        public SalesOpportunityDao(CrmDbContext context)
        {
            _context = context;
        }

        public IEnumerable<SalesOpportunity> GetSalesOpportunities(Guid customerId)
        {
            return _context.SalesOpportunities.Where(so => so.CustomerId == customerId).ToList();
        }
        public SalesOpportunity? GetSalesOpportunityById(Guid id) => _context.SalesOpportunities.Find(id);
        public void UpdateSalesOpportunity(SalesOpportunity opportunity)
        {
            _context.SalesOpportunities.Update(opportunity);
            _context.SaveChanges();
        }
    }
}