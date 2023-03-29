namespace GamesCRUD.Data.DTO;

public class GameDTO
{
    //[JsonIgnore]
    public int Id { get; set; }
  
    public string Name { get; set; }
   
    public string? Description { get; set; }

    public decimal Price { get; set; }

    public string Platform { get; set; } = null!;

    public DateTime ReleaseDate { get; set; }
    
    public int CategoryId { get; set; }
}
