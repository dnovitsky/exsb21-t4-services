using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Service
{
    public class PagedList<T>
        where T : class
    {
        public PagedList()
        {
            CurrentPage = 0;
            TotalPages = 0;
            this.PageList = new List<T>();
        }
        public IEnumerable<T> PageList { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public int TotalPageItems { get; set; }
    }
}
