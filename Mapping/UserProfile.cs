
using AutoMapper;
using Company.DTOs.Users;
using Microsoft.AspNetCore.Http.HttpResults;

namespace CompanyWebApp.Mapping
{
    public class UserProfile : Profile
    {
        public UserProfile() 
        {
            CreateMap<UserDto, Users>();
            CreateMap<CreateUserDto, Users>();

            CreateMap<UpdateMyProfileDto, Users>();
            CreateMap<ChangePasswordDto, Users>();

            CreateMap<UpdateUserDto, Users>();
        }

    }
}
