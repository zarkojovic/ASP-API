using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class Log 
    {
        public Guid LogId { get; set; }
        public string Message { get; set; }
        public string StrackTrace { get; set; }
        public DateTime Time { get; set; }
    }
}
