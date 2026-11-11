using Company.DTOs.Employee;
using Company.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly IEmployeeService _service;

    public EmployeeController(IEmployeeService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployee()
    {
        return Ok(await _service.GetEmployee());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployee(int id)
    {
        var employee = await _service.GetEmployee(id);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpGet("test-any")]
    public async Task<IActionResult> TestAny()
    {
        var result = await _service.TestAny();

        return Ok(result);
    }

    [HttpPost]
    public async Task<IActionResult> CreateEmployee(CreateEmployeeDto dto)
    {
        var employee = await _service.CreateEmployee(dto);

        return CreatedAtAction(
            nameof(GetEmployee),
            new { id = employee.Id },
            employee);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(
        int id,
        UpdateEmployeeDto dto)
    {
        var employee = await _service.UpdateEmployee(id, dto);

        if (employee == null)
            return NotFound();

        return Ok(employee);
    }

    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var deleted = await _service.DeleteEmployee(id);

        if (!deleted)
            return NotFound();

        return NoContent();
    }
}

