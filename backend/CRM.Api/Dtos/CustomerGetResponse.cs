namespace CRM.Api.DTOs
{
    public class CustomerGetResponse
    {
        public IEnumerable<CustomerDto> Data { get; set; }
        public PaginationMeta Meta { get; set; }

        public override string ToString()
        {
            return $"CustomerGetResponse: DataCount = {Data?.Count() ?? 0}, Meta = {Meta}";
        }
    }
}