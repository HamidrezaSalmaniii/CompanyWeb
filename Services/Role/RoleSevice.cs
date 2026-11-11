using AutoMapper;
using Company.Data;
using Company.DTOs.Roles;
using Company.Entities;
using Company.Services;
using CompanyWebApp.DTOs.Roles;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Services.Role
{
    public class RoleService : IRoleService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;
        public RoleService(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<RoleDto>> GetRole()
        {
            var role = await _context.Roles.ToListAsync();

            return _mapper.Map<List<RoleDto>>(role);
        }

        public async Task<RoleDto> GetRole(int id) 
        { 
            var role = _context.Roles.FirstOrDefault(e => e.Id == id);

            if (role == null)
                return null;

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> CreateRole(CreateRoleDto dto) 
        {
            var role = _mapper.Map<Roles>(dto);

            role.CreatedAt = DateTime.Now;
            role.UpdatedAt = DateTime.Now;

            _context.Roles.Add(role);

            await _context.SaveChangesAsync();
            return _mapper.Map<RoleDto>(role);
        }

        public async Task<RoleDto> UpdateRole(int id , UpdateRoleDto dto)
        {
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
                return null;

            _mapper.Map<Roles>(role);

            role.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<RoleDto>(role);
        }

        public async Task<bool> DeleteRole(int id)
        { 
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
                return false;

            _context.Remove(role);

            await _context.SaveChangesAsync();

            return true;


        }
    } 
}
