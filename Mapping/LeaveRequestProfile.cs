using AutoMapper;
using Company.DTOs;
using Company.DTOs.LeaveRequest;
using Company.Entities;
using CompanyWebApp.DTOs;

namespace CompanyWebApp.Mapping
{
    public class LeaveRequestProfile : Profile
    {
        public LeaveRequestProfile()
        {
            CreateMap<LeaveRequests, LeaveRequestDto>();

            CreateMap<CreateLeaveRequestDto, LeaveRequests>();
            CreateMap<UpdateLeaveRequestDto, LeaveRequests>();
        }
    }
}
