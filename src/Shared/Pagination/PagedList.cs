namespace Shared.Pagination;
public class PagedList<T>
{
    private readonly List<T> _sourceList;
    private readonly int _pageSize;

    public PagedList(IEnumerable<T> sourceList, int pageSize)
    {
        if (pageSize <= 0)
        {
            throw new ArgumentException("Page size must be greater than zero.");
        }

        _sourceList = sourceList.ToList() ?? throw new ArgumentNullException(nameof(sourceList));
        _pageSize = pageSize;
    }

    private int TotalPages => (int)Math.Ceiling((double)_sourceList.Count / _pageSize);

    private int PageSize => _pageSize;

    private int TotalItems => _sourceList.Count;

    public PagedResult<T> GetPagedResult(int pageNumber)
    {
        if (pageNumber < 1 || pageNumber > TotalPages)
        {
            throw new ArgumentOutOfRangeException(nameof(pageNumber), "Invalid page number.");
        }

        var startIndex = (pageNumber - 1) * _pageSize;
        var pageData = _sourceList.Skip(startIndex).Take(_pageSize).ToList();

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