using Company.Data;
using Company.DTOs;
using Company.DTOs.LeaveRequest;
using Company.Entities;
using Company.Services;
using CompanyWebApp.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LeaveRequestController : ControllerBase
{
    private readonly ILeaveRequestService _service;

    public LeaveRequestController(ILeaveRequestService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetLeaveRequests()
    {
        return Ok(await _service.GetLeaveRequest());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetLeaveRequest(int id)
    {
        var leaveRequest = await _service.GetLeaveRequest(id);

        if (leaveRequest == null)
            return NotFound();

        return Ok(leaveRequest);
    }

    [HttpPost]
    public async Task<IActionResult> CreateLeaveRequest(CreateLeaveRequestDto dto)
    {
        var leaverequest = await _service.CreateLeaveRequest(dto);

        return CreatedAtAction(
            nameof(GetLeaveRequest),
            new {id = leaverequest.Id },
            leaverequest);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateLeaveRequest(
        int id,
        UpdateLeaveRequestDto dto)
    {
        var leaverequest = await _service.UpdateLeaveRequest(id, dto);

        if (leaverequest == null)
            return NotFound();

        return Ok(leaverequest);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLeaveRequest(int id)
    {
        var leaveRequest = await _service.DeleteLeaveRequest(id);

        if (!leaveRequest)
            return NotFound();

        return NoContent();
    }
}