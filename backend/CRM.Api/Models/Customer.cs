using System.ComponentModel.DataAnnotations.Schema;

namespace CRM.Api.Models
{
    
    [Table("customer")]
    public class Customer
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string Email { get; init; }
        public string PhoneNumber { get; init; }
        public string Status { get; init; } // "Active", "Non-Active", "Lead"
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }
        // Navigation property for related SalesOpportunities
        public ICollection<SalesOpportunity> SalesOpportunities { get; set; } = new List<SalesOpportunity>();
        
    }
}