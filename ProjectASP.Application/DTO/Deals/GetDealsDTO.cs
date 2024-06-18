using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Deals
{
    public class GetDealsDTO
    {
        public string University { get; set; }
        public string Degree { get; set; }
        public string Program { get; set; }
        public int StageId { get; set; }
        public string StageName { get; set; }
    }
}
