namespace Based.Business.Interfaces
{
    public interface IInfo
    {
        int Total { get; set; }
        int TotalPages { get; set; }
        int CurrentPage { get; set; }
        int PageSize { get; set; }
    }
}