namespace Manga360.Api.Infrastructure.Mappings
{
    public class DomainToDTOProfile : Profile
    {
        public DomainToDTOProfile()
        {
            CreateMap<CategoriaEntity, CategoriaDTO>().ReverseMap();
            CreateMap<MangaEntity, MangaDTO>().ReverseMap();
            CreateMap<MangaEntity, MangaCategoriaDTO>()
                .ForMember(dto => dto.NomeCategoria, opt => opt.MapFrom(src => src.Categoria.Nome));
        }
    }
}