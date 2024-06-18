using ProjectASP.Application.DTO.Deals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Application.DTO.Users
{
    public class UserDetailDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Image { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public List<GetUserInfoDTO> UserInfo { get; set; }
        public List<GetDealsDTO> UserDeals { get; set; }
    }
}
