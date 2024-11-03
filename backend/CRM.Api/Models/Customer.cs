using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Api.Models
{
    
    [Table("customer")]
    public class Customer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        // Navigation property for related SalesOpportunities
        public ICollection<SalesOpportunity> SalesOpportunities { get; set; } = new List<SalesOpportunity>();
        
    }
}