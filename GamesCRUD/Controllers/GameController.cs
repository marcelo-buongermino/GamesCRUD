using GamesCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GamesCRUD.Repositories.Interfaces;

namespace GamesCRUD.Controllers;

[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    // define injecao de dependencia(repositorio) e mapper
    private readonly IGameRepository _gameRepository;
    private readonly IMapper _mapper;

    public GameController(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// Lista os games cadastrados no banco de dados
    /// </summary>       
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a listagem seja executada com sucesso</response>
    [HttpGet]
    public async Task<ActionResult<List<GameModel>>> ListAllGames()
    {
        try
        {
            List <GameModel> games = await _gameRepository.ListAllGames();
            return Ok(games);
        }
        catch (Exception ex)
        {            
            throw new Exception(ex.Message);

        }

    }

    /// <summary>
    /// Exibe um game cadastrado pelo ID
    /// </summary>
    /// <param name="id">Id game que será buscado no banco de dados</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a consulta seja feita com sucesso</response>
    [HttpGet("{id}")]
    public async Task<ActionResult<GameModel>> GetGameById(int id)
    {
        try
        {
            var game = await _gameRepository.FindGameById(id);
            return Ok(game);
        }
        catch (Exception ex)
        {

            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Adiciona um game ao banco de dados
    /// </summary>
    /// <param name="gameDTO">Objeto com os campos necessários para cadastro de um game</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public async Task<ActionResult<GameModel>> AddGame([FromBody] GameModel gameModel)
    {
        try
        {
            GameModel game = await _gameRepository.AddGame(gameModel);
            return CreatedAtAction(nameof(GetGameById),
                                    new { id = game.Id },
                                    game);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
        
    }


    /// <summary>
    /// Atualiza um objeto game no banco de dados
    /// </summary>
    /// <param name="id">Objeto com os campos necessários para atualizacao de seus campos</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a atualizacao seja feita com sucesso</response>
    [HttpPut("{id}")]
    public async Task<ActionResult<GameModel>> UpdateGame([FromBody] GameModel game, int id)
    {
        try
        {
            game.Id= id;
            await _gameRepository.UpdateGame(game, id);
            return NoContent();
        }
        catch (Exception ex)
        {

            return NotFound(ex.Message);
        }
    }

    /// <summary>
    /// Atualiza parcialmente um objeto game no banco de dados
    /// </summary>
    /// <param name="gameDTO">Qualquer propriedade com os campos necessários para atualizacao</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso a atualizacao seja feita com sucesso</response>
    //[HttpPatch("{id}")]
    //public IActionResult PartiallyUpdateGame(int id, JsonPatchDocument<GameDTO> patch)
    //{
    //    var game = _gameRepository.
    //    if (game == null) return NotFound();

    //    var filmeParaAtualizar = _mapper.Map<GameDTO>(game);
    //    patch.ApplyTo(filmeParaAtualizar, ModelState);

    //    if (!TryValidateModel(filmeParaAtualizar))
    //    {
    //        return ValidationProblem(ModelState);
    //    }

    //    _mapper.Map(filmeParaAtualizar, game);
    //    _context.SaveChanges();
    //    return NoContent();
    //}

    /// <summary>
    /// Remove um game do banco de dados
    /// </summary>
    ///  <param name="id">Id game que será buscado no banco de dados para a exclusao</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso exclusao seja feita com sucesso</response>
    [HttpDelete]
    public async Task<ActionResult<GameModel>> DeleteGame(int id)
    {        
        try
        {
            await _gameRepository.DeleteGame(id);
            return NoContent();
        }
        catch (Exception)
        {

            return NotFound(); 
        }
    }
}
