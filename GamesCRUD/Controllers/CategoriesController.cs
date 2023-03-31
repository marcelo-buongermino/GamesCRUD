using AutoMapper;
using GamesCRUD.Data.DTO;
using GamesCRUD.Models;
using GamesCRUD.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GamesCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        private readonly IMapper? _mapper;
        public CategoriesController(ICategoriesRepository categoriesRepository, IMapper? mapper)
        {
            _categoriesRepository = categoriesRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>> List()
        {
            try
            {
                var categories = await _categoriesRepository.ListAllCategoriesAsync();
                var categoriesDto = _mapper.Map<List<CategoryDTO>>(categories);
                return Ok(categoriesDto);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("games")]
        public async Task<ActionResult<List<Category>>> ListCategoriesWithGames()
        {
            try
            {
                var catWithGames = await _categoriesRepository.ListAllCategoriesWithGamesAsync();
                var catWithGamesDto = _mapper.Map<List<CategoryDTO>>(catWithGames);
                return Ok(catWithGamesDto);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro ao recuperar os dados. Tipo de excecao: {ex.Message}");
            }
        }
          


        //[HttpPost]
    }
}
