using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class FilterParametrsDtoModel
    {
        public FilterParametrsDtoModel()
        {
            FirstSearchingTextField = string.Empty;
            FirstSearchingTextString = string.Empty;
            SecondSearchingTextField = string.Empty;
            SecondSearchingTextString = string.Empty;
            SearchingDateField = string.Empty;
            SearchingDateString = string.Empty;
        }

        public FilterParametrsDtoModel(string firstField, string firstString, string secondField,
            string secondString, string dateField, string dateString)
        {
            FirstSearchingTextField = string.Empty;
            FirstSearchingTextString = string.Empty;
            SecondSearchingTextField = string.Empty;
            SecondSearchingTextString = string.Empty;
            SearchingDateField = string.Empty;
            SearchingDateString = string.Empty;
        }

        public string FirstSearchingTextField { get; set; }

        public string FirstSearchingTextString { get; set; }

        public string SecondSearchingTextField { get; set; }

        public string SecondSearchingTextString { get; set; }

        public string SearchingDateField { get; set; }

        public string SearchingDateString { get; set; }
    }
}
