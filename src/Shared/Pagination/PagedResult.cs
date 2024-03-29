namespace Shared.Pagination;

public class PagedResult<T>
{
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public int TotalItems { get; set; }
    public int TotalPages { get; set; }
    public IEnumerable<T>? Data { get; set; }
}