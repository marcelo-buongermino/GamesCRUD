using GamesCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GamesCRUD.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Annotations;
using GamesCRUD.Data.DTO;

namespace GamesCRUD.Controllers;

[Produces("application/json")]
[Route("api/[controller]")]
[ApiController]
public class GameController : ControllerBase
{
    // define injeções de dependencia(repositorios) e mapper
    private readonly IGameRepository _gameRepository;
    private readonly IMapper? _mapper;

    // construtor para teste unitario
    public GameController(IGameRepository repository)
    {
        _gameRepository = repository;
    }

    public GameController(IGameRepository gameRepository, IMapper mapper)
    {
        _gameRepository = gameRepository;
        _mapper = mapper;
    }


    // Métodos Action
    [HttpGet]
    [SwaggerOperation(
        Summary = "Lista todos os jogos da base de dados",
        Description = "Mostra uma listagem de todos os jogos cadastrados na base de dados"
    )]
    [SwaggerResponse(200, "Sucesso na operação", typeof(List<GameDTO>))]
    [SwaggerResponse(400, "Ocorreu um erro ao exibir a listagem!")]
    public async Task<ActionResult<List<GameDTO>>> ListAllGames()
    {
        try
        {
            var games = await _gameRepository.ListAllGamesAsync();
            var gamesDTO = _mapper.Map<List<GameDTO>>(games);
            return Ok(gamesDTO);
        }
        catch (Exception ex)
        {            
            return BadRequest(ex.Message);

        }
    }

 
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Lista um jogo especifico",
        Description = "Lista um jogo especifico, baseado no id enviado por parametro"
    )]
    [SwaggerResponse(200, "Sucesso na operação", typeof(List<GameDTO>))]
    [SwaggerResponse(404, "O game não foi encontrado!")]
    public async Task<ActionResult<GameDTO>> GetGameById(int id)
    {
        try
        {
            var game = await _gameRepository.FindGameByIdAsync(id);
            var gameDTO = _mapper.Map<GameDTO>(game);
            return Ok(gameDTO);
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Cria um novo jogo",
        Description = "Cria um jogo recebendo Nome, Categoria e Data de Lançamento"
    )]
    [SwaggerResponse(201, "O Game foi criado com sucesso!", typeof(GameDTO))]
    [SwaggerResponse(400, "Existem dados inválidos!")]
    public async Task<ActionResult<GameDTO>> AddGame([FromBody] GameDTO gamedto)
    {
        try
        {
            var game = _mapper.Map<Game>(gamedto);
            var createdObject = await _gameRepository.AddGameAsync(game);
            var gameDTO = _mapper.Map<GameDTO>(createdObject);
            return CreatedAtAction(nameof(GetGameById),
                                    new { id = game.Id },
                                    gameDTO);
        }
        catch (Exception ex)
        {

            return BadRequest(ex.Message);
        }
        
    }


    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Atualiza um jogo existente",
        Description = "Atualiza um jogo cadastrado na base de dados, recebendo Nome, Categoria e Data de Lançamento"
    )]
    [SwaggerResponse(204, "O Game foi atualizado com sucesso!", typeof(GameDTO))]
    //[SwaggerResponse(400, "Existem dados inválidos!")]
    [SwaggerResponse(404, "Não encontrado!")]
    public async Task<ActionResult> UpdateGame([FromBody] GameDTO gamedto, int id)
    {
        try
        {
            var game = _mapper.Map<Game>(gamedto);
            game.Id= id;
            await _gameRepository.UpdateGameAsync(game, id);
            return NoContent();
        }
        catch (Exception ex)
        {
            return NotFound(ex.Message);
        }
    }

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

 
    [HttpDelete]
    [SwaggerOperation(
        Summary = "Exclui um jogo da base de dados",
        Description = "Exclui um jogo cadastrada na base de dados, recebendo um ID como parametro"
    )]
    [SwaggerResponse(204, "Requisição bem sucedida")]
    [SwaggerResponse(404, "Erro na requisição, game não encontrado!")]
    public async Task<ActionResult> DeleteGameAsync(int id)
    {        
        try
        {
            await _gameRepository.DeleteGameAsync(id);
            return NoContent();
        }
        catch (Exception)
        {

            return NotFound(); 
        }
    }
}
