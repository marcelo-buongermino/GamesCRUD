using GamesCRUD.Models;
using GamesCRUD.Repositories;
using GamesCRUD.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GamesCRUD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoriesRepository _categoriesRepository;
        public CategoriesController(ICategoriesRepository categoriesRepository)
        {
            _categoriesRepository = categoriesRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<Category>>>List()
        {
            try
            {
                var categories = await _categoriesRepository.ListAllCategoriesAsync();
                return Ok(categories);
            }
            catch (Exception ex)
            {
                 return BadRequest(ex.Message);
            }            
        }
          


        //[HttpPost]
    }
}
