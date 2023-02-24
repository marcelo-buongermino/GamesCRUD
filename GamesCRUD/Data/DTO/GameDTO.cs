using System.ComponentModel.DataAnnotations;

namespace GamesCRUD.Data.DTO
{
    public class GameDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do jogo é obrigatorio")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "O nome deve conter de 2 a 50 caracteres")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "A categoria do jogo é obrigatoria")]
        [StringLength(50, ErrorMessage = "O tamanho da categoria não pode exceder 50 caracteres")]
        public string? Categoria { get; set; }

        [Required(ErrorMessage = "A data de lançamento é obrigatoria")]
        public DateTime DataLancamento { get; set; }
    }
}
