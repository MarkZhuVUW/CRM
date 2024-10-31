namespace CRM.Api.DTOs
{
    public class PaginationMeta
    {
        public int? TotalCount { get; set; }

        public override string ToString()
        {
            return $"PaginationMeta: TotalCount = {TotalCount}";
        }
    }
}