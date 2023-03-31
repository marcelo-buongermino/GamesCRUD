using GamesCRUD.Data;
using GamesCRUD.Models;
using GamesCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesCRUD.Repositories;

public class GameRepository : IGameRepository
{
    private readonly GameCrudDBContext _dbContext;

    public GameRepository(GameCrudDBContext gameCrudDBContext)
    {
        _dbContext = gameCrudDBContext;
    }

    public async Task<Game> FindGameByIdAsync(int id)
    {
        var game = await _dbContext.Games.FirstOrDefaultAsync(game => game.Id == id);
        if (game == null) 
        {
            throw new Exception("Game nao encontrado!");
        }
        return game;
    }

    public async Task<List<Game>> ListAllGamesAsync()
    {
        return await _dbContext.Games.AsNoTracking().Include(cat => cat.Category).ToListAsync();
    }

    public async Task<Game> AddGameAsync(Game game)
    {
        await _dbContext.Games.AddAsync(game);
        await _dbContext.SaveChangesAsync();

        return game;
    }

    public async Task<Game> UpdateGameAsync(Game game, int id)
    {
        var gameFound = await FindGameByIdAsync(id);

        if (gameFound != null)
        {
            //gameFound.Id = game.Id;
            gameFound.Name = game.Name;
            gameFound.Description = game.Description;
            gameFound.Category = game.Category;
            gameFound.Price = game.Price;
            gameFound.Platform = game.Platform;
            gameFound.ReleaseDate = game.ReleaseDate;

            _dbContext.Games.Update(gameFound);
            await _dbContext.SaveChangesAsync();
            return gameFound;
        }
        throw new Exception("Game não encontrado");

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

    public async Task<bool> DeleteGameAsync(int id)
    {
        Game gameFound = await FindGameByIdAsync(id);

        if (gameFound == null)
        {
            throw new Exception("Game inexistente");
        }

        _dbContext.Games.Remove(gameFound);
        await _dbContext.SaveChangesAsync();

        return true;
    }

}
