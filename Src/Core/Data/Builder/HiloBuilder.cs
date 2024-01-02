using Hilos.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class HiloConfiguration : IEntityTypeConfiguration<Hilo>
    {

        public void Configure(EntityTypeBuilder<Hilo> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).HasConversion(id => id.Value, value => new HiloId(value));
            builder.HasOne(h => h.Autor).WithMany().HasForeignKey(h => h.AutorId).IsRequired();
            builder.HasOne(h => h.Media).WithMany().HasForeignKey(h => h.MediaId).IsRequired();
            builder.HasOne(h => h.Subcategoria).WithMany().HasForeignKey(h => h.SubcategoriaId).IsRequired();
            builder.HasOne(h => h.Encuesta).WithMany().HasForeignKey(h => h.EncuestaId);
            builder.ComplexProperty(h => h.Titulo);
            builder.ComplexProperty(h => h.Descripcion);
            builder.ComplexProperty(h => h.Banderas);
        }
    }
}