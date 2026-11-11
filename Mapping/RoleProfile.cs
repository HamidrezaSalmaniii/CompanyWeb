using AutoMapper;
using Company.DTOs.Roles;
using Company.Entities;
using CompanyWebApp.DTOs.Roles;

namespace CompanyWebApp.Mapping
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<Roles, RoleDto>();
            CreateMap<CreateRoleDto, Roles>();
            CreateMap<UpdateRoleDto, Roles>();
        }
    }

}
