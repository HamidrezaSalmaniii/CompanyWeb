using AutoMapper;
using Company.DTOs.Employee;
using Company.Entities;

namespace Company.Mapping;

public class EmployeeProfile : Profile
{
    public EmployeeProfile()
    {
        CreateMap<Employees, EmployeeDto>()
            .ForMember(
                dest => dest.DepartmentName,
                opt => opt.MapFrom(src => src.Department!.Name))
            .ForMember(
                dest => dest.PositionTitle,
                opt => opt.MapFrom(src => src.Position!.Title));

        CreateMap<CreateEmployeeDto, Employees>();

        CreateMap<UpdateEmployeeDto, Employees>();
    }
}