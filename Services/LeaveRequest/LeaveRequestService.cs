using AutoMapper;
using Company.Data;
using Company.DTOs;
using Company.DTOs.Employee;
using Company.DTOs.LeaveRequest;
using Company.Entities;
using Company.Services;
using CompanyWebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace CompanyWebApp.Services.LeaveRequest
{
    public class LeaveRequestService :ILeaveRequestService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;
        public LeaveRequestService(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<LeaveRequestDto>> GetLeaveRequest()
        {
            var leaverequest = await _context.LeaveRequests
            .Include(l => l.Employee)
            .Include(l => l.Approver)
            .ToListAsync();

            return _mapper.Map<List<LeaveRequestDto>>(leaverequest);
        }

        public async Task<LeaveRequestDto> GetLeaveRequest(int id)
        {
            var leaverequest = await _context.LeaveRequests
                .FirstOrDefaultAsync(e => e.Id == id);

            return _mapper.Map<LeaveRequestDto>(leaverequest);
        }

        public async Task<LeaveRequestDto> CreateLeaveRequest(CreateLeaveRequestDto dto)
        {
            var leaverequest = _mapper.Map<LeaveRequests>(dto);
            leaverequest.ApprovedAt = DateTime.Now;
            leaverequest.CreatedAt = DateTime.Now;

            _context.LeaveRequests.Add(leaverequest);

            await _context.SaveChangesAsync();

            return _mapper.Map<LeaveRequestDto>(leaverequest);
        }

        public async Task<LeaveRequestDto?> UpdateLeaveRequest(
            int id,
            UpdateLeaveRequestDto dto)
        {
            var leaverequest = await _context.LeaveRequests.FindAsync(id);

            if (leaverequest == null)
                return null;

            _mapper.Map(dto, leaverequest);

            await _context.SaveChangesAsync();

            return _mapper.Map<LeaveRequestDto>(leaverequest);
        }

        public async Task<bool> DeleteLeaveRequest(int id)
        {
            var leaverequest = await _context.LeaveRequests.FindAsync(id);

            if (leaverequest == null)
                return false;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
