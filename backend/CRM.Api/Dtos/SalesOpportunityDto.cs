namespace CRM.Api.DTOs
{
    public class SalesOpportunityDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public Guid CustomerId { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}