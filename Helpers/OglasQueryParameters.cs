namespace TutorHubAPI.Helpers
{
    public class OglasQueryParameters
    {
        public string SortProperty { get; set; } = "";
        const int maxPageSize = 100;
        private int _pageNumber = 1;
        public int PageNumber
        {
            get => (_pageNumber > 0) ? _pageNumber : 1;
            set
            {
                _pageNumber = (value > 0) ? value : 1;
            }
        }
        private int _pageSize = 10;
        public int PageSize
        {
            get => _pageSize;
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;
            }
        }
        public string SearchText { get; set; } = "";
        public string SearchGrad { get; set; } = "";
        public string FilterType { get; set; } = "";
        public string FilterProperty { get; set; } = "";
    }
}
