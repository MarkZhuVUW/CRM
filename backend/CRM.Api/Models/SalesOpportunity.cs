using System.ComponentModel.DataAnnotations.Schema;


namespace CRM.Api.Models
{
    [Table("sales_opportunity")]
    public class SalesOpportunity
    {
        public Guid Id { get; init; }
        public Guid CustomerId { get; init; }
        public string Name { get; init; }
        public string Status { get; init; }
        public DateTime CreatedAt { get; init; }
        public DateTime UpdatedAt { get; init; }

        // Navigation property
        public Customer Customer { get; set; }

        public override string ToString()
        {
            return $"SalesOpportunity: Id={Id}, CustomerId={CustomerId}, Name={Name}, Status={Status}, CreatedAt={CreatedAt}, UpdatedAt={UpdatedAt}";
        }
    }
}