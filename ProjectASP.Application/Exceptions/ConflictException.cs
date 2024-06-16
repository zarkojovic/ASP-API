using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.Exceptions
{
    public class ConflictException : Exception 
    {
        public ConflictException(string reason) 
            : base()
        {
            
        }
    }
}
