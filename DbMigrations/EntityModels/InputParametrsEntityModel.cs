using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbMigrations.EntityModels
{
    public class InputParametrsEntityModel
    {
        public int PageNumber;
        public int PageSize;

        public int SortType;
        public string SortField;

        public string SearchingString;
    }
}
