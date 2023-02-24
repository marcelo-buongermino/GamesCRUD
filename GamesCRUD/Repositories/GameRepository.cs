using GamesCRUD.Data;
using GamesCRUD.Data.DTO;
using GamesCRUD.Models;
using GamesCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesCRUD.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly GameCrudDBContext _dbContext;

        public GameRepository(GameCrudDBContext gameCrudDBContext)
        {
            _dbContext = gameCrudDBContext;
        }

        public async Task<GameModel> FindGameById(int id)
        {
            var game = await _dbContext.Games.FirstOrDefaultAsync(game => game.Id == id);
            if (game == null) 
            {
                throw new Exception("Game nao encontrado!");
            }
            return game;
        }

        public async Task<List<GameModel>> ListAllGames()
        {
            return await _dbContext.Games.ToListAsync();
        }

        public async Task<GameModel> AddGame(GameModel game)
        {
            await _dbContext.Games.AddAsync(game);
            await _dbContext.SaveChangesAsync();

            return game;
        }

        public async Task<GameModel> UpdateGame(GameModel game, int id)
        {
            var gameFound = await FindGameById(id);

            if (gameFound == null)
            {
                throw new Exception("Game não encontrado");
            }

            gameFound.Id = game.Id;
            gameFound.Nome = game.Nome;
            gameFound.Categoria = game.Categoria;
            gameFound.DataLancamento = game.DataLancamento;

            _dbContext.Games.Update(gameFound);
            await _dbContext.SaveChangesAsync();
            return gameFound;

        }

        //public async Task<GameModel> PartiallyUpdateGame(GameModel game, int id)
        //{
        //    var gameFound = await FindGameById(id);

        //    if (gameFound == null)
        //    {
        //        throw new Exception("Game não encontrado");
        //    }

        //    gameFound.Id = gameFound.Id;
        //    gameFound.Nome = gameFound.Nome;
        //    gameFound.Categoria = gameFound.Categoria;
        //    gameFound.DataLancamento = gameFound.DataLancamento;

        //    _dbContext.Games.Update(gameFound);
        //    await _dbContext.SaveChangesAsync();
        //    return gameFound;
        //}

        public async Task<bool> DeleteGame(int id)
        {
            GameModel gameFound = await FindGameById(id);

            if (gameFound == null)
            {
                throw new Exception("Game inexistente");
            }

            _dbContext.Games.Remove(gameFound);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
