namespace SAPex.Models
{
    public class InputParametrsViewModel
    {
        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public int SortType { get; set; }

        public string SortField { get; set; }

        public string SearchingString { get; set; }
    }
}
