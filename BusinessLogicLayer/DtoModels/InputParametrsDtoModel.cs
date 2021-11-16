using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.DtoModels
{
    public class InputParametrsDtoModel
    {
        public int PageNumber;

        public int PageSize;

        public SortType SortingType;

        public string SortField;

    }

    public enum SortType
    {
        Ascending,
        Descending,
    }
}
