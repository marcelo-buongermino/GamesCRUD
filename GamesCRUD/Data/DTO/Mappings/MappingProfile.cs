using AutoMapper;
using GamesCRUD.Models;

namespace GamesCRUD.Data.DTO.Mappings;

public class MappingProfile: Profile
{
    public MappingProfile()
    {
        CreateMap<Game, GameDTO>().ReverseMap();
        CreateMap<Category, CategoryDTO>().ReverseMap();
    }
}
