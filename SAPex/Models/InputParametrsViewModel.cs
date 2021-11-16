using System.ComponentModel;

namespace SAPex.Models
{
    public class InputParametrsViewModel
    {
        public InputParametrsViewModel()
        {
            PageNumber = 1;
            PageSize = 20;
            SortingType = 0;
            SortField = string.Empty;
        }

        public InputParametrsViewModel(int pgNumber, int pgSize, SortType sType, string sField)
        {
            PageNumber = pgNumber;
            PageSize = pgSize;
            SortingType = sType;
            SortField = sField;
        }

        public int PageNumber { get; set; }

        public int PageSize { get; set; }

        public SortType SortingType { get; set; }

        public string SortField { get; set; }
    }

    public enum SortType
    {
        Ascending,
        Descending,
    }
}