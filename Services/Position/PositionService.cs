using AutoMapper;
using Company.Data;
using Company.DTOs.Position;
using Company.Entities;
using Company.Services;
using CompanyWebApp.Exceptions;
using Microsoft.EntityFrameworkCore;

namespace CompanyWebApp.Services.Position
{
    public class PositionService : IPositionService
    {
        private readonly CompanyDbContext _context;
        private readonly IMapper _mapper;
        public PositionService(CompanyDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<PositionDto>> GetPosition()
        {
            var position = await _context.Positions
                .Include(p => p.Department)
                .Include(p => p.Employees)
                .ToListAsync();


            return _mapper.Map<List<PositionDto>>(position);
        }

        public async Task<PositionDto?> GetPosition(int id)
        {
            var position = await _context.Positions
                .Include(p => p.Department)
                .Include(p => p.Employees)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (position == null)
                return null;

            return _mapper.Map<PositionDto>(position);
        }

        public async Task<PositionDto> CreatePosition(CreatePositionDto dto)
        {
            // Create Employee

            var position = _mapper.Map<Positions>(dto);

            position.CreatedAt = DateTime.Now;
            position.UpdatedAt = DateTime.Now;

            _context.Positions.Add(position);

            await _context.SaveChangesAsync();

            return _mapper.Map<PositionDto>(position);
        }

        public async Task<PositionDto?> UpdatePosition(
            int id,
            UpdatePositionDto dto)
        {
            var position = await _context.Positions.FindAsync(id);

            if (position == null)
                return null;

            _mapper.Map(dto, position);

            position.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return _mapper.Map<PositionDto>(position);
        }

        public async Task<bool> DeletePosition(int id)
        {
            var position = await _context.Positions.FindAsync(id);

            if (position == null)
                return false;

            var isDepartmentManager = await _context.Departments.AnyAsync(d => d.ManagerId == id);

            if (isDepartmentManager)
                throw new Exception("Position is a manager of a department.");
            _context.Positions.Remove(position);

            await _context.SaveChangesAsync();

            return true;
        }

    }
}

