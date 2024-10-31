

namespace CRM.Api.DTOs
{
    public class CustomerFilter
    {
        public string? Name { get; set; }
        public string? Status { get; set; }

        public override string ToString()
        {
            return $"CustomerFilter: Name = {Name}, Status = {Status ?? "Not Specified"}";
        }
    }
}