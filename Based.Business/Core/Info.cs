using Based.Business.Interfaces;

namespace Based.Business.Core
{
    public class Info : IInfo
    {
        public int Total { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
    }
}