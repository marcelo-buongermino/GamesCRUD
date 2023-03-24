using GamesCRUD.Models;

namespace GamesCRUD.Repositories.Interfaces;

public interface ICategoriesRepository
{
    Task<List<Category>> ListAllCategoriesAsync();
    Task<Category> FindCategoryByIdAsync(int id);
    Task<Category> AddCategoryAsync(Category category);
    Task<Category> UpdateCategoryAsync(Category category, int id);
    Task<bool> DeleteCategoryAsync(int id);
}
