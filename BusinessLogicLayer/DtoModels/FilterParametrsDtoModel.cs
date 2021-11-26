﻿using System;
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
            SearchingStringAll = string.Empty;
            FirstSearchingTextField = string.Empty;
            FirstSearchingTextString = string.Empty;
            SecondSearchingTextField = string.Empty;
            SecondSearchingTextString = string.Empty;
            SearchingDateField = string.Empty;
            SearchingDateString = string.Empty;
            SearchingStatus = SearchStatus.None;
        }

        public FilterParametrsDtoModel(string firstField, string firstString, string secondField,
            string secondString, string dateField, string dateString, SearchStatus searchStatus, string searchingStringALL)
        {
            SearchingStringAll = searchingStringALL;
            FirstSearchingTextField = firstField;
            FirstSearchingTextString = firstString;
            SecondSearchingTextField = secondField;
            SecondSearchingTextString = secondString;
            SearchingDateField = dateField;
            SearchingDateString = dateString;
            SearchingStatus = searchStatus;
        }

        public string SearchingStringAll { get; set; }
        public string FirstSearchingTextField { get; set; }

        public string FirstSearchingTextString { get; set; }

        public string SecondSearchingTextField { get; set; }

        public string SecondSearchingTextString { get; set; }

        public string SearchingDateField { get; set; }

        public string SearchingDateString { get; set; }

        public SearchStatus SearchingStatus { get; set; }
    }

    public enum SearchStatus
    {
        None = -1,
        Draft,
        Active,
        Registration,
        Application,
        Inprogress,
        Archive,
    }
}
