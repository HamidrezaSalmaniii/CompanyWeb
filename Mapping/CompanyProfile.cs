using AutoMapper;
using Company.DTOs.Company;
using Company.Entities;

namespace CompanyWebApp.Mapping
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Companies, CompanyDto>();

            CreateMap<CreateCompanyDto, Companies>();
            CreateMap<UpdateCompanyDto, Companies>();
        }
    }
}
