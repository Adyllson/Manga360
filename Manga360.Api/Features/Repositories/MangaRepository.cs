namespace Manga360.Api.Features.Repositories
{
    public class MangaRepository : Repository<MangaEntity>, IMangaRepository
    {
        public MangaRepository(AppDbContext context) : base(context) { }
        public async Task<IEnumerable<MangaEntity>> GetMangasPorCategoriaAsync(int categoriaId)
        {
            return await _db.Mangas.Where(b => b.CategoriaId == categoriaId).ToListAsync();
        }
        public async Task<IEnumerable<MangaEntity>> LocalizaMangaComCategoriaAsync(string criterio)
        {
            return await _db.Mangas.AsNoTracking()
                .Include(b => b.Categoria)
                .Where(b => b.Titulo.Contains(criterio) ||
                            b.Autor.Contains(criterio) ||
                            b.Descricao.Contains(criterio) ||
                            b.Categoria.Nome.Contains(criterio))
                .ToListAsync();
        }
    }
}