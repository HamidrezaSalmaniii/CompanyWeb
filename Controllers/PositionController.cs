using Company.Data;
using Company.Entities;
using Microsoft.AspNetCore.Mvc;
using Company.Services;
using Microsoft.EntityFrameworkCore;
using Company.DTOs.Position;

namespace Company.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PositionController : ControllerBase
{
    private readonly IPositionService _service;

    public PositionController(IPositionService service)
    {
        _service = service;
    }

    [HttpGet]
    public async Task<IActionResult> GetPositions()
    {

        return Ok(await _service.GetPosition());
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetPosition(int id)
    {
        var position = await _service.GetPosition(id);

        if (position == null)
            return NotFound();

        return Ok(position);
    }

    [HttpPost]
    public async Task<IActionResult> CreatePosition(CreatePositionDto dto)
    {
        var position = await _service.CreatePosition(dto);

        return CreatedAtAction(
            nameof(GetPosition),
            new { id = position.Id },
            position);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdatePosition(
        int id,
        UpdatePositionDto dto)
    {
        var position = await _service.UpdatePosition(id, dto);

        if (position == null)
            return null;

        return Ok(position);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePosition(int id)
    {
        var position = await _service.DeletePosition(id);

        if (position == null)
            return NotFound();

        return NoContent();
    }
}