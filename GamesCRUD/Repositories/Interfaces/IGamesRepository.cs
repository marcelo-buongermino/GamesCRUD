using GamesCRUD.Data.DTO;
using GamesCRUD.Models;

namespace GamesCRUD.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<Game>> ListAllGamesAsync();
        Task<Game> FindGameByIdAsync(int id);
        Task<Game> AddGameAsync(Game game);
        Task<Game> UpdateGameAsync(Game game, int id);
        //Task<GameModel> PartiallyUpdateGame(GameModel game, int id);
        Task<bool> DeleteGameAsync(int id);

    }
}
