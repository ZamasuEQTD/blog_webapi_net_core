using Encuestas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class EncuestaConfiguration : IEntityTypeConfiguration<Encuesta>
    {
        public void Configure(EntityTypeBuilder<Encuesta> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasConversion(id => id.Value, value => new EncuestaId(value));
            builder.HasMany(e => e.Opciones).WithOne().HasForeignKey(o => o.EncuestaId).IsRequired();
        }
    }
    public class EncuestaOpcionConfiguration : IEntityTypeConfiguration<EncuestaOpcion>
    {
        public void Configure(EntityTypeBuilder<EncuestaOpcion> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(id => id.Value, value => new EncuestaOpcionId(value));
            builder.Property(o => o.Nombre).HasConversion(nombre => nombre.Value, value => NombreDeOpcion.Create(value).Value!);
        }
    }
}