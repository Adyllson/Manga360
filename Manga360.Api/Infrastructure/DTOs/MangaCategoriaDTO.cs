namespace Manga360.Api.Infrastructure.DTOs
{
    public class MangaCategoriaDTO
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O título é requerido")]
        [MinLength(3)]
        [MaxLength(100)]
        [DisplayName("Título")]
        public string Titulo { get; set; } = null!;

        [Required(ErrorMessage = "A descrição é obrigatória")]
        [MinLength(5)]
        [MaxLength(200)]
        [DisplayName("Descrição")]
        public string Descricao { get; set; } = null!;

        [Required(ErrorMessage = "O autor é requerido")]
        [MinLength(3)]
        [MaxLength(200)]
        public string Autor { get; set; } = null!;

        [Required(ErrorMessage = "A editora é requerida")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Editora { get; set; } = null!;

        [Required(ErrorMessage = "O número de páginas é requerido")]
        [Range(1, 9999)]
        public int Paginas { get; set; }

        [Display(Name = "Data Publicação")]
        [DataType(DataType.Text)]
        [Required(ErrorMessage = "A data de publicação é requerida")]
        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy hh:mm}", ApplyFormatInEditMode = true)]
        public DateTime Publicacao { get; set; }

        [Required(ErrorMessage = "O formato é requerido")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Formato { get; set; } = null!;

        [Required(ErrorMessage = "A cor é requerida")]
        [MinLength(3)]
        [MaxLength(50)]
        public string Cor { get; set; } = null!;

        [Required(ErrorMessage = "A origem é requerida")]
        [MinLength(3)]
        [MaxLength(80)]
        public string Origem { get; set; } = null!;

        [MaxLength(250)]
        public string? Imagem { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório")]
        [Column(TypeName = "decimal(10,2)")]
        [DisplayFormat(DataFormatString = "{0:C2}")]
        [DataType(DataType.Currency)]
        [DisplayName("Preço")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O estoque é obrigatório")]
        [Range(1, 999)]
        public int Estoque { get; set; }

        public string NomeCategoria { get; set; } = null!;
    }
}