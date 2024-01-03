using Categorias.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class CategoriaBuilder : IEntityTypeConfiguration<Categoria>
    {
        public void Configure(EntityTypeBuilder<Categoria> builder)
        {
            builder.Property(e => e.Id).HasConversion(id => id.Value, value => new CategoriaId(value));
            builder.HasKey(e => e.Id);
            builder.HasMany(c => c.Subcategorias).WithOne().HasForeignKey(s => s.CategoriaId).IsRequired();
            builder.ComplexProperty(c => c.Nombre);
        }
    }

    public class SubcategoriaBuilder : IEntityTypeConfiguration<Subcategoria>
    {
        public void Configure(EntityTypeBuilder<Subcategoria> builder)
        {
            builder.Property(e => e.Id).HasConversion(id => id.Value, value => new SubcategoriaId(value));
            builder.HasKey(e => e.Id);
            builder.Property(s => s.EsNSFW).IsRequired();
            builder.ComplexProperty(c => c.Nombre).IsRequired();
            builder.ComplexProperty(c => c.NombreCorto).IsRequired();
        }
    }
}