using GamesCRUD.Models;

namespace GamesCRUD.Repositories.Interfaces
{
    public interface IGameRepository
    {
        Task<List<GameModel>> ListAllGames();
        Task<GameModel> FindGameById(int id);
        Task<GameModel> AddGame(GameModel game);
        Task<GameModel> Update(GameModel game, int id);
        Task<bool> DeleteGame(int id);

    }
}
