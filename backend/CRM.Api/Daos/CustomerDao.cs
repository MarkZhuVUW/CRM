using CRM.Api.Context;
using CRM.Api.Models;

namespace CRM.Api.Dao
{
    public class CustomerDao : ICustomerDao
    {
        private readonly CrmDbContext _context;

        public CustomerDao(CrmDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Customer> GetCustomers(int pageNumber, int pageSize, string filter, string sort)
        {
            var customers = _context.Customers.AsQueryable();

            if (!string.IsNullOrWhiteSpace(filter))
            {
                customers = customers.Where(c => c.Name.Contains(filter) || c.Status.Contains(filter));
            }

            customers = sort switch
            {
                "name" => customers.OrderBy(c => c.Name),
                "status" => customers.OrderBy(c => c.Status),
                _ => customers.OrderBy(c => c.CreatedAt)
            };

            return customers.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        public Customer? GetCustomerById(Guid id) => _context.Customers.Find(id);

        public void UpdateCustomer(Customer customer)
        {
            _context.Customers.Update(customer);
            _context.SaveChanges();
        }
    }
}