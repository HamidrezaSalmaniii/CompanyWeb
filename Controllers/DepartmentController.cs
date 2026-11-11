using Company.DTOs.Department;
using Company.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DepartmentController : ControllerBase
{
    private readonly IDepartmentService _service;

    public DepartmentController(IDepartmentService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetDepartments()
    {
        return Ok(await _service.GetDepartment());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartment(int id)
    {
        var department = await _service.GetDepartment(id);

        if (department == null)
            return NotFound();

        return Ok(department);
    }

    [HttpPost]
    public async Task<IActionResult> CreateDepartment(CreateDepartmentDto dto)
    {
       var department = await _service.CreateDepartment(dto);

        return CreatedAtAction(
            nameof(GetDepartment),
            new { id = department.Id },
            department);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(int id,
        UpdateDepartmentDto dto)
    {
        var department = await _service.UpdateDepartment(id,dto);

        if (department == null)
            return NotFound();

        return Ok(department);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(int id)
    {
        var department = await _service.DeleteDepartment(id);

        if (department == null)
            return NotFound();

        return NoContent();
    }

}