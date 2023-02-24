using GamesCRUD.Data.DTO;
using GamesCRUD.Models;

namespace GamesCRUD.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<GameModel>> ListAllGames();
        Task<GameModel> FindGameById(int id);
        Task<GameModel> AddGame(GameModel game);
        Task<GameModel> UpdateGame(GameModel game, int id);
        //Task<GameModel> PartiallyUpdateGame(GameModel game, int id);
        Task<bool> DeleteGame(int id);

    }
}
