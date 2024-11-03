using System.ComponentModel.DataAnnotations.Schema;


namespace CRM.Api.Models
{
    [Table("sales_opportunity")]
    public class SalesOpportunity
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
        public string Name { get; set; }
        public string Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        // Navigation property
        public Customer Customer { get; set; }

        public override string ToString()
        {
            return $"SalesOpportunity: Id={Id}, CustomerId={CustomerId}, Name={Name}, Status={Status}, CreatedAt={CreatedAt}, UpdatedAt={UpdatedAt}";
        }
    }
}