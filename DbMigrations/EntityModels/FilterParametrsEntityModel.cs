using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class FilterParametrsEntityModel
    {
        public FilterParametrsEntityModel()
        {
            FirstSearchingTextField = string.Empty;
            FirstSearchingTextString = string.Empty;
            SecondSearchingTextField = string.Empty;
            SecondSearchingTextString = string.Empty;
            SearchingDateField = string.Empty;
            SearchingDateString = string.Empty;
        }

        public FilterParametrsEntityModel(string firstField, string firstString, string secondField,
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
