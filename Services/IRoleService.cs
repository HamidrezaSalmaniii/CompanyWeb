using Company.DTOs.Roles;
using CompanyWebApp.DTOs.Roles;

namespace Company.Services
{
    public interface IRoleService
    {
        Task<List<RoleDto>> GetRole();
        Task<RoleDto?> GetRole(int id);
        Task<RoleDto> CreateRole(CreateRoleDto dto);
        Task<RoleDto?> UpdateRole(int id , UpdateRoleDto dto);
        Task<bool> DeleteRole(int id);
    }
}
