using Company.Data;
using Company.DTOs.Company;
using Company.Entities;
using Company.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Company.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CompanyController : ControllerBase
{
    private readonly ICompanyService _service;

    public CompanyController(ICompanyService service)
    {
        _service = service;
    }

    // GET: api/Company
    [HttpGet]
    public async Task<IActionResult> GetCompanies()
    {
        return Ok(await _service.GetCompany());
    }

    // GET: api/Company/1
    [HttpGet("{id}")]
    public async Task<IActionResult> GetCompany(int id)
    {
        var company = await _service.GetCompany(id);

        if (company == null)
            return NotFound();

        return Ok(company);
    }

    // POST: api/Company
    [HttpPost]
    public async Task<IActionResult> CreateCompany(CreateCompanyDto dto)
    {
        var company = await _service.CreateCompany(dto);

        return CreatedAtAction(
            nameof(GetCompany),
            new { id = company.Id },
            company);
    }

    // PUT: api/Company/1
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCompany(
        int id,
        UpdateCompanyDto dto)
    {
        var company = await _service.UpdateCompany(id, dto);

        if (company == null)
            return NotFound();

        return Ok(company);
    }

    // DELETE: api/Company/1
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCompany(int id)
    {
        var company = await _service.DeleteCompany(id);

        if (!company)
            return NotFound();

        return NoContent();
    }
}