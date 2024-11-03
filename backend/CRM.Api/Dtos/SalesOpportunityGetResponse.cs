namespace CRM.Api.DTOs
{
    public class SalesOpportunityGetResponse
    {
        public IEnumerable<SalesOpportunityDto> Data { get; set; }

        public override string ToString()
        {
            return $"SalesOpportunityGetResponse: DataCount = {Data?.Count() ?? 0}";
        }
    }
}