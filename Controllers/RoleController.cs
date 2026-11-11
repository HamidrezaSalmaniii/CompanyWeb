using Company.Data;
using Company.DTOs.Roles;
using Company.Entities;
using Company.Services;
using CompanyWebApp.DTOs.Roles;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RoleController : ControllerBase
{
    private readonly IRoleService _service;

    public RoleController(IRoleService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetRoles()
    {
        return Ok(await _service.GetRole());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetRole(int id)
    {
        var role = await _service.GetRole(id);

        if (role == null)
            return NotFound();

        return Ok(role);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRole(CreateRoleDto dto)
    {
        var role = await _service.CreateRole(dto);

        return CreatedAtAction(
            
            nameof(GetRole),
            new {id = role.Id},
            role);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateRole(int id, UpdateRoleDto dto)
    {
        var role = await _service.UpdateRole(id,dto);

        if (role == null)
            return BadRequest();

        return Ok(role);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteRole(int id)
    {
        var role = await _service.DeleteRole(id);

        if(!role)
             return NotFound();

        return NoContent();
    }
}