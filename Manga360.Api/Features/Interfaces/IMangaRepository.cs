namespace Manga360.Api.Features.Interfaces
{
    public interface IMangaRepository : IRepository<MangaEntity>
    {
        Task<IEnumerable<MangaEntity>> GetMangasPorCategoriaAsync(int categoriaId);
        Task<IEnumerable<MangaEntity>> LocalizaMangaComCategoriaAsync(string criterio);
    }
}