namespace GamesCRUD.Models
{
    public class GameModel
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Categoria { get; set; }
        public DateTime DataLancamento { get; set; }
    }
}
