#nullable disable

using Newtonsoft.Json;

namespace GamesCRUD.Models
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? CreatedAt { get; set; }
        //[JsonIgnore]
        public ICollection<Game> Games { get; set; }
    }
}