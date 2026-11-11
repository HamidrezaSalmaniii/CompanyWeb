using Company.DTOs.Users;

namespace Company.Services
{
    public interface IUserService
    {
        Task<List<UserDto>> GetUser();
        Task<UserDto?> GetUser(int id);
        Task<UserDto> CreateUser(CreateUserDto dto);
        Task<UserDto> ChangePassword(int id,ChangePasswordDto dto);
        Task<UserDto> UpdateUser(int id , UpdateUserDto dto);
        Task<UserDto> UpdateMyProfile(int id, UpdateMyProfileDto dto);
        Task<bool> DeleteUser (int id);
    }
}
