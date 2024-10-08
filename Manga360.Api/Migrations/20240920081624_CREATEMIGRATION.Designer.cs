﻿// <auto-generated />
using System;
using Manga360.Api.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Manga360.Api.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240920081624_CREATEMIGRATION")]
    partial class CREATEMIGRATION
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Manga360.Api.Domain.Entities.Categoria.CategoriaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("NVARCHAR");

                    b.HasKey("Id");

                    b.ToTable("TBL_CATEGORIA", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Nome = "Aventura"
                        },
                        new
                        {
                            Id = 2,
                            Nome = "Ação"
                        },
                        new
                        {
                            Id = 3,
                            Nome = "Drama"
                        },
                        new
                        {
                            Id = 4,
                            Nome = "Romance"
                        },
                        new
                        {
                            Id = 5,
                            Nome = "Ficção"
                        });
                });

            modelBuilder.Entity("Manga360.Api.Domain.Entities.Manga.MangaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Autor")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("int");

                    b.Property<string>("Cor")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Descricao")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Editora")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Estoque")
                        .HasColumnType("int");

                    b.Property<string>("Formato")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Imagem")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Origem")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Paginas")
                        .HasColumnType("int");

                    b.Property<decimal>("Preco")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)");

                    b.Property<DateTime>("Publicacao")
                        .HasColumnType("datetime2");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoriaId");

                    b.ToTable("TBL_MANGA", (string)null);
                });

            modelBuilder.Entity("Manga360.Api.Domain.Entities.Manga.MangaEntity", b =>
                {
                    b.HasOne("Manga360.Api.Domain.Entities.Categoria.CategoriaEntity", "Categoria")
                        .WithMany("Mangas")
                        .HasForeignKey("CategoriaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Manga360.Api.Domain.Entities.Categoria.CategoriaEntity", b =>
                {
                    b.Navigation("Mangas");
                });
#pragma warning restore 612, 618
        }
    }
}
