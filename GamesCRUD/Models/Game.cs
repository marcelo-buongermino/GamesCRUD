namespace GamesCRUD.Models
{
    public class Game
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Categoria { get; set; }
        public string? DataLancamento { get; set; }
    }
}
