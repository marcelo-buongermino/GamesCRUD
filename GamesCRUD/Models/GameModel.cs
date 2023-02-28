using Swashbuckle.AspNetCore.Annotations;
using System.Security.Cryptography;

namespace GamesCRUD.Models
{
    public class GameModel
    {
        [SwaggerSchema(Description = "Incremental ID", ReadOnly = true)]
        public int Id { get; set; }

        [SwaggerSchema(Description = "Nome do game")]
        public string? Nome { get; set; }

        [SwaggerSchema(Description = "Categoria do game")]
        public string? Categoria { get; set; }

        [SwaggerSchema(Description = "Data de lançamento do game em formato ISO UTC", Format = "date")]
        public DateTime DataLancamento { get; set; }
    }
}
