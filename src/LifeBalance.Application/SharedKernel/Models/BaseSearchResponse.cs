namespace LifeBalance.Application.SharedKernel.Models;

public class BaseSearchResponse<T>
{
    public long DurationInMillisecond { get; set; }
    public int TotalCount { get; set; }
    public int TotalPage => TotalCount / PageSize + (TotalCount % PageSize > 0 ? 1 : 0);
    public int PageSize { get; set; }
    public int PageIndex { get; set; }
    private readonly List<T> _data;
    public IEnumerable<T> Data => _data;

    public BaseSearchResponse()
    {
        _data = [];
    }
    
    public void AddRangeData(IEnumerable<T> data)
    {
        _data.AddRange(data);
    }
    
    public void Add(T item)
    {
        _data.Add(item);
    }
    
    public BaseSearchResponse(long duration, int totalCount, int pageSize, int pageIndex, IEnumerable<T> data)
    {
        DurationInMillisecond = duration;
        TotalCount = totalCount;
        PageSize = pageSize;
        PageIndex = pageIndex;
        _data = [..data];
    }
}