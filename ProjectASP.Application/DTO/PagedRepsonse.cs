using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO
{
    public class PagedResponse<TDto>
        where TDto : class
    {
        public IEnumerable<TDto> Data { get; set; }
        public int PerPage { get; set; }
        public int TotalCount { get; set; }
        public int Pages
        {
            get
            {
                //101 - 10 -> 11
                return (int)Math.Ceiling((double)TotalCount / PerPage);
            }
        }
        public int CurrentPage { get; set; }
    }
}
