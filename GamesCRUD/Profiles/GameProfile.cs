using AutoMapper;
using GamesCRUD.Data.DTO;
using GamesCRUD.Models;

namespace GamesCRUD.Profiles;

public class GameProfile : Profile
{
    public GameProfile()
    {
        CreateMap<GameDTO, Game>();
    }
}
