using Company.DTOs.Company;
using Company.DTOs.Position;
using Company.DTOs.Position;

namespace Company.Services
{
    public interface IPositionService
    {
        Task<List<PositionDto>> GetPosition();

        Task<PositionDto?> GetPosition(int id);

        Task<PositionDto> CreatePosition(CreatePositionDto dto);

        Task<PositionDto?> UpdatePosition(
            int id,
            UpdatePositionDto dto);

        Task<bool> DeletePosition(int id);
    }
}
