namespace Manga360.Api.Domain.Entities.Categoria
{
    public sealed class CategoriaEntity : Entity
    {
        public string Nome { get; private set; } = null!;
        public CategoriaEntity(string nome)
        {
            ValidateDomain(nome);
        }
        public CategoriaEntity(int id, string nome)
        {
            DomainExceptionValidation.When(id < 0, "Id inválido.");
            Id = id;
            ValidateDomain(nome);
        }
        public void Update(string nome)
        {
            ValidateDomain(nome);
        }
        private void ValidateDomain(string nome)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome),
                "Nome é obrigatório");

            DomainExceptionValidation.When(nome.Length < 3,
               "Nome inválido");

            Nome = nome;
        }
        public IEnumerable<MangaEntity> Mangas { get; set; } = null!;
    }
}