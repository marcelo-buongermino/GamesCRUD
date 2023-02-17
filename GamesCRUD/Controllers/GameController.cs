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
        /// Adiciona um game ao banco de dados
        /// </summary>
        /// <param name="gameDTO">Objeto com os campos necessários para cadastro de um game</param>
        /// <returns>IActionResult</returns>
        /// <response code="201">Caso inserção seja feita com sucesso</response>
        [HttpGet]
        public IEnumerable<GameDTO> ListAllGames([FromQuery] int skip = 0,
        [FromQuery] int take = 50)
        {
            return _mapper.Map<List<GameDTO>>(_context.Games.Skip(skip).Take(take));
        }

        [HttpGet("{id}")]
        public IActionResult GetGameById(int id)
        {
            var game = _context.Games.FirstOrDefault(game => game.Id == id);
            if (game == null) { return NotFound(); }
            var gameDTO = _mapper.Map<GameDTO>(game);
            return Ok(gameDTO);
        }

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

        [HttpPut("{id}")]
        public IActionResult UpdateGame(int id, [FromBody] GameDTO gameDTO)
        {
            var game = _context.Games.FirstOrDefault(game => game.Id == id);
            if (game == null) return NotFound();
            _mapper.Map(gameDTO, game);
            _context.SaveChanges();
            return NoContent();
        }


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
