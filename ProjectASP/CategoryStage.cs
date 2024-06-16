using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Domain
{
    public class CategoryStage
    {
        public int CategoryId { get; set; }
        public int StageId { get; set; }
        public virtual Stage Stage { get; set; }
        public virtual Category Category { get; set; }

    }
}
