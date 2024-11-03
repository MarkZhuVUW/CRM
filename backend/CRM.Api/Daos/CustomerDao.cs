using CRM.Api.Context;
using CRM.Api.Dao;
using CRM.Api.DTOs;
using CRM.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Daos
{
    public class CustomerDao : ICustomerDao
    {
        private readonly CrmDbContext _context;

        public CustomerDao(CrmDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Customer>> GetCustomers(int pageNumber, int pageSize, CustomerFilter filter, string sort, string sortDirection)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                customers = customers.Where(c => c.Name.StartsWith(filter.Name));
            }

            if (!string.IsNullOrWhiteSpace(filter.Status))
            {
                customers = customers.Where(c => c.Status == filter.Status);
            }

            if (!string.IsNullOrWhiteSpace(sort))
            {
                customers = sort switch
                {
                    "name" => sortDirection == "desc" ? customers.OrderByDescending(c => c.Name) : customers.OrderBy(c => c.Name),
                    "status" => sortDirection == "desc" ? customers.OrderByDescending(c => c.Status) : customers.OrderBy(c => c.Status),
                    _ => customers
                };
            }

            return await customers.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();
        }

        public async Task<int> GetTotalCount(CustomerFilter filter)
        {
            var query = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                query = query.Where(c => c.Name.Contains(filter.Name));
            }

            if (filter.Status != null)
            {
                query = query.Where(c => c.Status == filter.Status);
            }

            return await query.CountAsync();
        }

        public async Task<bool> CustomerExists(Guid customerId)
        {
            return await _context.Customers.AnyAsync(c => c.Id == customerId);
        }

        public async Task<Customer?> GetCustomerById(Guid id) => await _context.Customers.FindAsync(id);
        
        public async Task UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}