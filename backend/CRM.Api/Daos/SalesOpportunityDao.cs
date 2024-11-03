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

        public async Task<IEnumerable<SalesOpportunity>> GetSalesOpportunities(Guid customerId)
        {
            return await _context.SalesOpportunities
                .Where(so => so.CustomerId == customerId)
                .ToListAsync();
        }

        public async Task<SalesOpportunity?> GetSalesOpportunityById(Guid id)
        {
            return await _context.SalesOpportunities.FindAsync(id);
        }

        public async Task CreateSalesOpportunity(SalesOpportunity opportunity)
        {
            await _context.SalesOpportunities.AddAsync(opportunity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateSalesOpportunity(SalesOpportunity opportunity)
        {
            _context.SalesOpportunities.Update(opportunity);
            await _context.SaveChangesAsync();
        }
    }
}