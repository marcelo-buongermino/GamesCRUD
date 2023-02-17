using GamesCRUD.Data;
using GamesCRUD.Models;

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using GamesCRUD.Data.DTO;
using Microsoft.AspNetCore.JsonPatch;

namespace GamesCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        // define injecao de dependencia e mapper
        private GameCrudDBContext _context;
        private IMapper _mapper;

        public GameController(GameCrudDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        /// <summary>
        /// Lista os games cadastrados no banco de dados
        /// </summary>       
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a listagem seja executada com sucesso</response>
        [HttpGet]
        public IEnumerable<GameDTO> ListAllGames([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
        {
            return _mapper.Map<List<GameDTO>>(_context.Games.Skip(skip).Take(take));
        }

        /// <summary>
        /// Exibe um game cadastrado pelo ID
        /// </summary>
        /// <param name="id">Id game que será buscado no banco de dados</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso inserção seja feita com sucesso</response>
        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            var game = _context.Games.FirstOrDefault(game => game.Id == id);
            if (game == null) { return NotFound(); }
            var gameDTO = _mapper.Map<GameDTO>(game);
            return Ok(gameDTO);
        }

        /// <summary>
        /// Adiciona um game ao banco de dados
        /// </summary>
        /// <param name="gameDTO">Objeto com os campos necessários para cadastro de um game</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpPost]
        public IActionResult AddGame([FromBody] GameDTO gameDTO)
        {
            GameModel game = _mapper.Map<GameModel>(gameDTO);
            _context.Games.Add(game);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetGameById),
                new { id = game.Id },
                game
                );
        }


        /// <summary>
        /// Atualiza um objeto game no banco de dados
        /// </summary>
        /// <param name="gameDTO">Objeto com os campos necessários para atualizacao de seus campos</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a atualizacao seja feita com sucesso</response>
        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, [FromBody] GameDTO gameDTO)
        {
            var game = _context.Games.FirstOrDefault(game => game.Id == id);
            if (game == null) return NotFound();
            _mapper.Map(gameDTO, game);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Atualiza parcialmente um objeto game no banco de dados
        /// </summary>
        /// <param name="gameDTO">Qualquer propriedade com os campos necessários para atualizacao</param>
        /// <returns>IActionResult</returns>
        /// <response code="200">Caso a atualizacao seja feita com sucesso</response>
        [HttpPatch("{id}")]
        public IActionResult PartialUpdateGame(int id, JsonPatchDocument<GameDTO> patch)
        {
            var game = _context.Games.FirstOrDefault(game => game.Id == id);
            if (game == null) return NotFound();

            var filmeParaAtualizar = _mapper.Map<GameDTO>(game);
            patch.ApplyTo(filmeParaAtualizar, ModelState);

            if (!TryValidateModel(filmeParaAtualizar))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(filmeParaAtualizar, game);
            _context.SaveChanges();
            return NoContent();
        }

        /// <summary>
        /// Remove um game do banco de dados
        /// </summary>
        ///  <param name="id">Id game que será buscado no banco de dados para a exclusao</param>
        /// <returns>IActionResult</returns>
        /// <response code="204">Caso exclusao seja feita com sucesso</response>
        [HttpDelete]
        public IActionResult DeleteGame(int id)
        {
            var game = _context.Games.FirstOrDefault(game => game.Id == id);
            if (game == null) { return NotFound(); }
            _context.Games.Remove(game);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
