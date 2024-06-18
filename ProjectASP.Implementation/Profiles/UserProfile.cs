using AutoMapper;
using ProjectASP.Application.DTO.Users;
using ProjectASP.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectASP.Implementation.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, GetUsersDTO>()
                .ForMember(x => x.Image, y => y.MapFrom(i => i.ProfileImage));
        }
    }
}
