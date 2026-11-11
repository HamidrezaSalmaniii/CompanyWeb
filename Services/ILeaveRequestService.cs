using Company.DTOs;
using Company.DTOs.LeaveRequest;
using CompanyWebApp.DTOs;

namespace Company.Services;

public interface ILeaveRequestService
{
    Task<List<LeaveRequestDto>> GetLeaveRequest();

    Task<LeaveRequestDto?> GetLeaveRequest(int id);

    Task<LeaveRequestDto> CreateLeaveRequest(CreateLeaveRequestDto dto);

    Task<LeaveRequestDto?> UpdateLeaveRequest(
        int id,
        UpdateLeaveRequestDto dto);

    Task<bool> DeleteLeaveRequest(int id);
}