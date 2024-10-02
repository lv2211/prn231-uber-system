namespace UberSystem.Dto.Helpers
{
    public class PaginationHelper
    {
        public static PagedResponse<T> GetPagedResponse<T>(
            IQueryable<T> query,
            int pageNumber,
            int pageSize)
        {
            var totalItems = query.Count();
            var items = query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return new PagedResponse<T>(items, totalItems, pageNumber, pageSize);
        }
    }
}
