using CRM.Api.Context;
using CRM.Api.Dao;
using CRM.Api.DTOs;
using CRM.Api.Models;

namespace CRM.Api.Daos
{
    public class CustomerDao : ICustomerDao
    {
        private readonly CrmDbContext _context;

        public CustomerDao(CrmDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers(int pageNumber, int pageSize, CustomerFilter filter, string sort)
        {
            var customers = _context.Customers.AsQueryable();


            if (!string.IsNullOrWhiteSpace(filter.Name))
            {
                customers = customers.Where(c => c.Name.Contains(filter.Name));
            }
            
            customers = customers.Where(c => c.Status == filter.Status);
            customers = sort switch
            {
                "name" => customers.OrderBy(c => c.Name),
                "status" => customers.OrderBy(c => c.Status),
                _ => customers
            };

            
            return customers.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
            
        }
        public int GetTotalCount(CustomerFilter filter)
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
            

            return query.Count();
        }
        public Customer? GetCustomerById(Guid id) => _context.Customers.Find(id);

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}