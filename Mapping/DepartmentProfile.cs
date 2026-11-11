using AutoMapper;
using Company.DTOs.Department;
using Company.Entities;

namespace CompanyWebApp.Mapping
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Departments, DepartmentDto>();

            CreateMap<CreateDepartmentDto, Departments>();
            CreateMap<UpdateDepartmentDto, Departments>();
        }
    }
}
