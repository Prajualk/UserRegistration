namespace UserRegistration.Api.Commons
{
    public class PaginatedList
    {
        public int CurrentPage { get; set; } = 1;
        public int TotalPage { get; set; }
        public int PageSize { get; set; } = 10;
        public int TotalCount { get; set; }
        public string Search { get; set; }

    }
}
