using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Talabat.Shared
{
    public class PaginatedResult<TEnitiy>
    {
        public PaginatedResult(int pageIndex, int pageSize, int totalCount, IEnumerable<TEnitiy> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            TotalCount = totalCount;
            Data = data;
        }

        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<TEnitiy> Data { get; set; }   
    }
}
