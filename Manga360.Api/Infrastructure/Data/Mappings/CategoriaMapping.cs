namespace Manga360.Api.Infrastructure.Data.Mappings
{
    public class CategoriaMapping : IEntityTypeConfiguration<CategoriaEntity>
    {
        public void Configure(EntityTypeBuilder<CategoriaEntity> builder)
        {

            builder.ToTable("TBL_CATEGORIA");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Nome)
                    .HasMaxLength(100)
                    .IsRequired(true)
                    .HasColumnType("NVARCHAR");

            builder.HasMany(x => x.Mangas)
                    .WithOne(x => x.Categoria)
                    .HasForeignKey(x => x.CategoriaId);
            builder.HasData(
              new CategoriaEntity(1, "Aventura"),
              new CategoriaEntity(2, "Ação"),
              new CategoriaEntity(3, "Drama"),
              new CategoriaEntity(4, "Romance"),
              new CategoriaEntity(5, "Ficção")
              );
        }
    }
}