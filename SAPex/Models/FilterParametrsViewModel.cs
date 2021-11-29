using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SAPex.Models
{
    public class FilterParametrsViewModel
    {
        public FilterParametrsViewModel()
        {
            SearchingStringAll = string.Empty;
            FirstSearchingTextField = string.Empty;
            FirstSearchingTextString = string.Empty;
            SecondSearchingTextField = string.Empty;
            SecondSearchingTextString = string.Empty;
            SearchingDateField = string.Empty;
            SearchingDateString = string.Empty;
            SearchingStatus = "None";
        }

        public FilterParametrsViewModel(string firstField, string firstString, string secondField,
            string secondString, string dateField, string dateString, string searchStatus, string searchingStringALL)
        {
            FirstSearchingTextField = firstField;
            FirstSearchingTextString = firstString;
            SecondSearchingTextField = secondField;
            SecondSearchingTextString = secondString;
            SearchingDateField = dateField;
            SearchingDateString = dateString;
            SearchingStatus = searchStatus;
            SearchingStringAll = searchingStringALL;
        }

        public string SearchingStringAll { get; set; }

        public string FirstSearchingTextField { get; set; }

        public string FirstSearchingTextString { get; set; }

        public string SecondSearchingTextField { get; set; }

        public string SecondSearchingTextString { get; set; }

        public string SearchingDateField { get; set; }

        public string SearchingDateString { get; set; }

        public string SearchingStatus { get; set; }
    }
}
