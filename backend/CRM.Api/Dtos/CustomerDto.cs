namespace CRM.Api.DTOs
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string Status { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedAt { get; set; }
        
        public DateTime UpdatedAt { get; set; }
        
        public override string ToString()
        {
            return $"CustomerDto [Id={Id}, Name={Name}, Status={Status}, Email={Email}, PhoneNumber={PhoneNumber}, CreatedAt={CreatedAt}, UpdatedAt={UpdatedAt}]";
        }
    }
}