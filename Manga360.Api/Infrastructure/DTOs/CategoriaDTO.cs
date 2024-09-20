namespace Manga360.Api.Infrastructure.DTOs
{
    public class CategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é requerido")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; } = null!;
    }
}