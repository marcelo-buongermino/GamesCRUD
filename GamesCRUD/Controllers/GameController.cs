using GamesCRUD.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GamesCRUD.Repositories.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

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

    [HttpGet]
    [SwaggerOperation(
        Summary = "Lista todos os jogos da base de dados",
        Description = "Mostra uma listagem de todos os jogos cadastrados na base de dados"
    )]
    [SwaggerResponse(200, "Sucesso na operação", typeof(List<GameModel>))]
    [SwaggerResponse(400, "Ocorreu um erro ao exibir a listagem!")]
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

 
    [HttpGet("{id}")]
    [SwaggerOperation(
        Summary = "Lista um jogo especifico",
        Description = "Lista um jogo especifico, baseado no id enviado por parametro"
    )]
    [SwaggerResponse(200, "Sucesso na operação", typeof(List<GameModel>))]
    [SwaggerResponse(404, "O game não foi encontrado!")]
    [SwaggerResponse(400, "Ocorreu um erro ao buscar pelo game especificado!")]
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

    
    [HttpPost]
    [SwaggerOperation(
        Summary = "Cria um novo jogo",
        Description = "Cria um jogo recebendo Nome, Categoria e Data de Lançamento"
    )]
    [SwaggerResponse(201, "O Game foi criado com sucesso!", typeof(GameModel))]
    [SwaggerResponse(400, "Existem dados inválidos!")]
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


    [HttpPut("{id}")]
    [SwaggerOperation(
        Summary = "Atualiza um jogo existente",
        Description = "Atualiza um jogo cadastrada na base de dados, recebendo Nome, Categoria e Data de Lançamento"
    )]
    [SwaggerResponse(204, "O Game foi atualizado com sucesso!")]
    [SwaggerResponse(400, "Existem dados inválidos!")]
    [SwaggerResponse(404, "Erro na requisição, game não encontrnado!")]
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
    [SwaggerResponse(400, "Falha na requisição")]
    [SwaggerResponse(404, "Erro na requisição, game não encontrado!")]
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
