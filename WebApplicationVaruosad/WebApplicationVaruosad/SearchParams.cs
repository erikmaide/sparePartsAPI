using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationVaruosad.Controllers
{
    public class SearchParams
    {
        const int maxPageSize = 50;
        private int _pageSize = 10;
        public int PageNumber { get; set; }
        public string SearchByName { get; set; }
        public string SortedBy { get; set; }
        public string Name { get; set; }
        public int PageSize
        {
            get
            {
                return _pageSize;
            }
            set
            {
                _pageSize = (value > maxPageSize) ? maxPageSize : value;//pageSize = Math.Min(value, maxPageSize); //(value > maxPageSize) ? maxPageSize : value
            }
        }

    }
}