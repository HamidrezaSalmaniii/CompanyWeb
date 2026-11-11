using AutoMapper;
using Company.Data;
using Company.DTOs.Users;
using Company.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.ComponentModel.DataAnnotations;

namespace CompanyWebApp.Services.User
{
    public class UserService : IUserService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Users> _passwordHasher;
        public UserService(CompanyDbContext context, IMapper mapper, IPasswordHasher<Users> passwordHasher) 
        {
            _context = context;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<List<UserDto>> GetUser()
        {
            var user = await _context.Users.ToListAsync();
            return _mapper.Map<List<UserDto>>(user);
        }

        public async Task<UserDto> GetUser(int id )
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            if (user == null)
                return null;

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> CreateUser(CreateUserDto dto)
        {
            var user = _mapper.Map<UserDto>(dto);

            user.UpdatedAt = DateTime.Now;
            user.CreatedAt = DateTime.Now;
           
            _context.Add(user);
            _context.SaveChanges();

            return _mapper.Map<UserDto>(_context);
        }
        
        public async Task<UserDto> UpdateUser(int id ,UpdateUserDto dto)
        {
            var user = await _context.Users.FindAsync(id);            

            if (user == null)
                return null;

            if (!string.IsNullOrWhiteSpace(dto.Password))
            {
                user.PasswordHash = _passwordHasher.HashPassword(
                    user,
                    dto.Password);
            }

            _mapper.Map<UserDto>(user);

            user.UpdatedAt = DateTime.Now;
            
            await _context.SaveChangesAsync();
            return _mapper.Map<UserDto>(_context);
        }


        public async Task<UserDto> UpdateMyProfile(
            int id,
            UpdateMyProfileDto dto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return null;

            _mapper.Map(dto, user);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<UserDto> ChangePassword(int id ,ChangePasswordDto dto)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return null;

            var result = _passwordHasher.VerifyHashedPassword(
                user,
                user.PasswordHash,
                dto.CurrentPassword);

            if (result == PasswordVerificationResult.Failed)
                throw new ValidationException("Current password is incorrect.");

            user.PasswordHash = _passwordHasher.HashPassword(
                user,
                dto.NewPassword);

            await _context.SaveChangesAsync();

            return _mapper.Map<UserDto>(user);
        }

        public async Task<bool> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user == null)
                return false;

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return true;
        }
    }
}

