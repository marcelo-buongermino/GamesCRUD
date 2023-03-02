using GamesCRUD.Data.DTO;
using GamesCRUD.Models;

namespace GamesCRUD.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> ListAllGames();
        Task<Game> FindGameById(int id);
        Task<Game> AddGame(Game game);
        Task<Game> UpdateGame(Game game, int id);
        //Task<GameModel> PartiallyUpdateGame(GameModel game, int id);
        Task<bool> DeleteGame(int id);

    }
}
