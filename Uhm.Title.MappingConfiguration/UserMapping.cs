using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Uhm.Title.Data.Models;
using Uhm.Title.Dto;

namespace Uhm.Title.MappingConfiguration
{
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            CreateMap<UserDto, User>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.Password))
                ;
        }
    }
}
