using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistencia.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.HasKey(e => e.Id).HasName("PRIMARY");

            builder.ToTable("productos");

            builder.HasIndex(e => e.CategoriaId, "categoria_id");

            builder.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("id");
            builder.Property(e => e.CategoriaId)
                .HasMaxLength(50)
                .HasColumnName("categoria_id");
            builder.Property(e => e.Imagen)
                .HasMaxLength(255)
                .HasColumnName("imagen");
            builder.Property(e => e.Precio)
                .HasPrecision(10, 2)
                .HasColumnName("precio");
            builder.Property(e => e.Titulo)
                .HasMaxLength(255)
                .HasColumnName("titulo");

            builder.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productos_ibfk_1");
        }
    }
}