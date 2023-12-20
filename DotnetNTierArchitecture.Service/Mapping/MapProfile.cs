using AutoMapper;
using DotnetNTierArchitecture.Core.DTOs;
using DotnetNTierArchitecture.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotnetNTierArchitecture.Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile() 
        {
            // entity'den dto çevirme
            CreateMap<Team,TeamDto>().ReverseMap(); 
            CreateMap<User,UserDto>().ReverseMap(); 
            CreateMap<UserProfile,UserProfileDto>().ReverseMap(); 

            //dto'dan entity'e çevirme
            CreateMap<TeamDto, Team>();
        }
    }
}
