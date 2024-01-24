using AutoMapper;
using ResponseModelWebApi.DTOs;
using ResponseModelWebApi.Models;

namespace ResponseModelWebApi.Mappings
{
    public class DtoProfile : Profile
    {
        public DtoProfile()
        {
            CreateMap<CreateUserDto, User>().ReverseMap();
            CreateMap<UserDto, User>().ReverseMap();
            CreateMap<UpdateUserDto, User>().ReverseMap();
        }
    }
}
