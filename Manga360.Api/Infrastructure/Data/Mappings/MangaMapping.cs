
namespace Manga360.Api.Infrastructure.Data.Mappings
{
    public class MangaMapping : IEntityTypeConfiguration<MangaEntity>
    {
        public void Configure(EntityTypeBuilder<MangaEntity> builder)
        {
            builder.ToTable("TBL_MANGA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Titulo)
                    .HasMaxLength(100)
                    .IsRequired(true);
            builder.Property(x => x.Descricao)
                    .HasMaxLength(200)
                    .IsRequired(true);
            builder.Property(x => x.Autor)
                    .HasMaxLength(200)
                    .IsRequired(true);
            builder.Property(x => x.Editora)
                    .HasMaxLength(100)
                    .IsRequired(true);
            builder.Property(x => x.Formato)
                    .HasMaxLength(100)
                    .IsRequired(true);
            builder.Property(x => x.Cor)
                    .HasMaxLength(50)
                    .IsRequired(true);
            builder.Property(x => x.Origem)
                    .HasMaxLength(100)
                    .IsRequired(true);
            builder.Property(x => x.Imagem)
                    .HasMaxLength(250)
                    .IsRequired(true);
            builder.Property(x => x.Preco)
                    .HasPrecision(10, 2);
        }
    }
}