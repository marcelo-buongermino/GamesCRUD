using GamesCRUD.Data;
using GamesCRUD.Models;
using GamesCRUD.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace GamesCRUD.Repositories;

public class CategoriesRepository : ICategoriesRepository
{
    private readonly GameCrudDBContext _context;
    public CategoriesRepository(GameCrudDBContext context)
    {
        _context = context;
    }

    public async Task<Category> AddCategoryAsync(Category category)
    {
        await _context.Categories.AddAsync(category);
        await _context.SaveChangesAsync();

        return category;
    }

    public async Task<List<Category>> ListAllCategoriesAsync()
    {
        List<Category> categories = await _context.Categories.ToListAsync();
        return categories;
    }

    public async Task<Category> FindCategoryByIdAsync(int id)
    {
        Category? category = await _context.Categories.FirstOrDefaultAsync(cat => cat.Id == id);

        if (category is not null) 
        {
            return category;
        }
        throw new Exception("Categoria não encontrada");
        
    }

    public async Task<Category> UpdateCategoryAsync(Category category, int id)
    {
        Category? categoryFound = await FindCategoryByIdAsync(id);
        if (categoryFound is not null) 
        {
            categoryFound.Id = category.Id;
            categoryFound.Name = category.Name;

            _context.Categories.Update(categoryFound);
            await _context.SaveChangesAsync();
            return categoryFound;
        }

        throw new Exception("Categoria não encontrada");
    }

    public async Task<bool> DeleteCategoryAsync(int id)
    {
        Category categoryFound = await FindCategoryByIdAsync(id);

        if (categoryFound != null) 
        {
            _context.Categories.Remove(categoryFound);
            await _context.SaveChangesAsync();
            return true;
        }
        throw new Exception("Game não foi encontrado");
        
    }
}
