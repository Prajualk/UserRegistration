using Microsoft.EntityFrameworkCore;

namespace UserRegistration.Api.Common
{
    public class PaginatedList<T> : List<T>
    {
        public int currentPage { get; set; }
        public int totalPage { get; set; }
        public int pagesize { get; set; }
        public int totalcount { get; set; }
        public bool Hasprevious => currentPage > 1;
        public bool Hasnext => currentPage < totalPage;
        public PaginatedList(List<T> items, int count, int pagenumber, int pagesize)
        {
            totalcount = count;
            pagesize = pagesize;
            currentPage = pagenumber;
            totalPage = (int)Math.Ceiling(count / (double)pagesize);
            AddRange(items);


        }
        public static async Task<PaginatedList<T>> TopagedList(IQueryable<T> source, int pageNumber, int pagesize)
        {
            var count = await source.CountAsync();
            var items = await source.Skip((pageNumber - 1))
        }
    }
}
