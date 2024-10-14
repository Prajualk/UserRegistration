using AutoMapper;
using Domain.Dto;
using Domain.Entity;
using UserRegistration.Domain.Dto;
using UserRegistration.Domain.Entity;

namespace UserRegistration.Application.Mapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<User, UserDto2>().ReverseMap();
            CreateMap<Rolecs, RoleDto2>().ReverseMap();
            CreateMap<Rolecs, RolesDto>().ReverseMap();
            CreateMap<Images, ImageDto>().ReverseMap();
        }
    }
}
