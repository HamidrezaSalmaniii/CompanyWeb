using AutoMapper;
using Company.DTOs.Position;
using Company.Entities;
using Company.DTOs.Position;

namespace Company.Mapping
{
    public class PositionProfile:Profile
    {
        public PositionProfile() { 

        CreateMap<Positions, PositionDto>();
        CreateMap<CreatePositionDto, Positions>();
        CreateMap<UpdatePositionDto, Positions>();

        }


    }
}
