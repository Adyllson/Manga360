namespace Manga360.Api.Domain.Entities.Manga
{
    public sealed class MangaEntity : Entity
    {
        public string Titulo { get; set; } = null!;
        public string Descricao { get; set; } = null!;
        public string Autor { get; set; } = null!;
        public string Editora { get; set; } = null!;
        public int Paginas { get; set; }
        public DateTime Publicacao { get; set; }
        public string Formato { get; set; } = null!;
        public string Cor { get; set; } = null!;
        public string Origem { get; set; } = null!;
        public string Imagem { get; set; } = null!;
        public decimal Preco { get; set; }
        public int Estoque { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaEntity Categoria { get; set; } = null!;
    }
}