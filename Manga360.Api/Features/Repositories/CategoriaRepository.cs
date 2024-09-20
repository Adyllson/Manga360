namespace Manga360.Api.Features.Repositories
{
    public class CategoriaRepository: Repository<CategoriaEntity>, ICategoriaRepository
    {
        public CategoriaRepository(AppDbContext context) : base(context) { }
    }
}