﻿// <auto-generated />
using Domain.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Persistence.Data.Migrations
{
    [DbContext(typeof(ApiContext))]
    partial class ApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id");

                    b.Property<string>("Nombre")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("nombre");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.ToTable("categorias", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.Property<string>("Id")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("id");

                    b.Property<string>("CategoriaId")
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("categoria_id");

                    b.Property<string>("Imagen")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("imagen");

                    b.Property<decimal>("Precio")
                        .HasPrecision(10, 2)
                        .HasColumnType("decimal(10,2)")
                        .HasColumnName("precio");

                    b.Property<string>("Titulo")
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("titulo");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "CategoriaId" }, "categoria_id");

                    b.ToTable("productos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Producto", b =>
                {
                    b.HasOne("Domain.Entities.Categoria", "Categoria")
                        .WithMany("Productos")
                        .HasForeignKey("CategoriaId")
                        .HasConstraintName("productos_ibfk_1");

                    b.Navigation("Categoria");
                });

            modelBuilder.Entity("Domain.Entities.Categoria", b =>
                {
                    b.Navigation("Productos");
                });
#pragma warning restore 612, 618
        }
    }
}
