using GamesCRUD.Models;

namespace GamesCRUD.Data.DTO;

public class CategoryDTO
{
    public int Id { get; set; }
    public string Name { get; set; }

    public ICollection<GameDTO> Games { get; set; }
}
