namespace Shared.Pagination;
public class PagedList<T>
{
    private readonly List<T> _sourceList;

    public PagedList(IEnumerable<T> sourceList, int pageSize)
    {
        if (pageSize <= 0)
        {
            throw new ArgumentException("Page size must be greater than zero.");
        }

        _sourceList = sourceList.ToList() ?? throw new ArgumentNullException(nameof(sourceList));
        PageSize = pageSize;
    }

    private int TotalPages => (int)Math.Ceiling((double)_sourceList.Count / PageSize);

    private int PageSize { get; }

    private int TotalItems => _sourceList.Count;

    public PagedResult<T> GetPagedResult(int pageNumber)
    {
        if (pageNumber < 1 || pageNumber > TotalPages)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Invalid page number.");
        }

        var startIndex = (pageNumber - 1) * PageSize;
        var pageData = _sourceList.Skip(startIndex).Take(PageSize).ToList();

        return new PagedResult<T>
        {
            PageNumber = pageNumber,
            PageSize = PageSize,
            TotalItems = TotalItems,
            TotalPages = TotalPages,
            Data = pageData
        };
    }
}