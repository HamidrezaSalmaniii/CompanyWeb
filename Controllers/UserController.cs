
using Company.Data;
using Company.DTOs.Users;
using Company.Entities;
using Company.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Company.Controllers;

[Authorize]
[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly CompanyDbContext _context;
    private readonly IUserService _service;
    private readonly IPasswordHasher<Users> _passwordHasher;

    public UserController(
        CompanyDbContext context,
        IUserService service,
        IPasswordHasher<Users> passwordHasher)
    {
        _context = context;
        _service = service;
        _passwordHasher = passwordHasher;
    }

    // GET: api/User
    [HttpGet]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> GetUsers()
    {
        var users = await _context.Users
            .Select(u => new
            {
                u.Id,
                u.UserName,
                u.Email,
                u.EmployeeId,
                u.RoleId,
                u.IsActive
            })
            .ToListAsync();

        return Ok(users);
    }

    // GET: api/User/5
    [HttpGet("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> GetUser(int id)
    {
        var user = await _context.Users
            .Where(u => u.Id == id)
            .Select(u => new
            {
                u.Id,
                u.UserName,
                u.Email,
                u.EmployeeId,
                u.RoleId,
                u.IsActive
            })
            .FirstOrDefaultAsync();

        if (user == null)
            return NotFound();

        return Ok(user);
    }

    // POST: api/User
    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> CreateUser(CreateUserDto dto)
    {
        var roleExists = await _context.Roles
            .AnyAsync(r => r.Id == dto.RoleId);

        if (!roleExists)
            return BadRequest("Invalid RoleId.");

        var user = new Users
        {
            UserName = dto.UserName,
            Email = dto.Email,
            EmployeeId = dto.EmployeeId,
            RoleId = dto.RoleId,
            IsActive = dto.IsActive
        };

        // Hash password before saving
        user.PasswordHash = _passwordHasher.HashPassword(
            user,
            dto.Password
        );

        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return CreatedAtAction(
            nameof(GetUser),
            new { id = user.Id },
            new
            {
                user.Id,
                user.UserName,
                user.Email,
                user.EmployeeId,
                user.RoleId,
                user.IsActive
            }
        );
    }

    // PUT: api/User/5
    [HttpPut("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> UpdateUser(
        int id,
        UpdateUserDto dto)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFound();

        var roleExists = await _context.Roles
            .AnyAsync(r => r.Id == dto.RoleId);

        if (!roleExists)
            return BadRequest("Invalid RoleId.");

        user.UserName = dto.UserName;
        user.Email = dto.Email;
        user.EmployeeId = dto.EmployeeId;
        user.RoleId = dto.RoleId;
        user.IsActive = dto.IsActive;

        // Only hash password when a new password is provided
        if (!string.IsNullOrWhiteSpace(dto.Password))
        {
            user.PasswordHash = _passwordHasher.HashPassword(
                user,
                dto.Password
            );
        }

        await _context.SaveChangesAsync();

        return Ok(new
        {
            user.Id,
            user.UserName,
            user.Email,
            user.EmployeeId,
            user.RoleId,
            user.IsActive
        });
    }

    // PUT: api/User/me
    [HttpPut("me")]
    public async Task<IActionResult> UpdateMyProfile(
        UpdateMyProfileDto dto)
    {
        var userIdValue = User.FindFirst(
            ClaimTypes.NameIdentifier)?.Value
            ?? User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (!int.TryParse(userIdValue, out int userId))
            return Unauthorized();

        var result = await _service.UpdateMyProfile(userId, dto);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // PUT: api/User/me/password
    [HttpPut("me/password")]
    public async Task<IActionResult> ChangePassword(
        ChangePasswordDto dto)
    {
        var userIdValue = User.FindFirst(
            ClaimTypes.NameIdentifier)?.Value
            ?? User.FindFirst(JwtRegisteredClaimNames.Sub)?.Value;

        if (!int.TryParse(userIdValue, out int userId))
            return Unauthorized();

        try
        {
            var result = await _service.ChangePassword(userId, dto);

            if (result == null)
                return NotFound();

            return Ok(new
            {
                Message = "Password changed successfully."
            });
        }
        catch (ValidationException ex)
        {
            return BadRequest(new
            {
                Message = ex.Message
            });
        }
    }

    // DELETE: api/User/5
    [HttpDelete("{id}")]
    [Authorize(Roles = "Administrator")]
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);

        if (user == null)
            return NotFound();

        _context.Users.Remove(user);

        await _context.SaveChangesAsync();

        return NoContent();
    }
}
