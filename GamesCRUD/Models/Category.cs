#nullable disable

namespace GamesCRUD.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        public List<Game> Games { get; set; }
    }
}