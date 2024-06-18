using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Users
{
    public class SearchUsersDTO : PagedSearch
    {
        public string? Username { get; set; }
        public string? Email { get; set; }
        public int? PackageId { get; set; }
    }
}
