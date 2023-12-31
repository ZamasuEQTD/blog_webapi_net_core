using Encuestas.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class EncuestaConfiguration : IEntityTypeConfiguration<Encuesta>
    {
        public void Configure(EntityTypeBuilder<Encuesta> builder)
        {
            builder.Property(e => e.Id).HasConversion(id => id.Value, value => new EncuestaId(value));
            builder.HasKey(e => e.Id);
            builder.HasMany(e => e.Opciones).WithOne().HasForeignKey(o => o.EncuestaId).IsRequired();
        }
    }
    public class EncuestaOpcionConfiguration : IEntityTypeConfiguration<EncuestaOpcion>
    {
        public void Configure(EntityTypeBuilder<EncuestaOpcion> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(id => id.Value, value => new EncuestaOpcionId(value));
            builder.Property(o => o.Nombre).HasConversion(nombre => nombre.Value, value => NombreDeOpcion.Create(value).Value);
            builder.Property(o => o.Votos).HasConversion(votos => votos.Value, value => VotosDeEncuesta.Create(value).Value);
        }
    }
    public class VotacionDeEncuestaConfiguration : IEntityTypeConfiguration<VotacionDeEncuesta>
    {
        public void Configure(EntityTypeBuilder<VotacionDeEncuesta> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(id => id.Value, value => new VotacionDeEncuestaId(value));
            builder.HasOne(o => o.Opcion).WithMany().HasForeignKey(o => o.OpcionId);
            builder.HasOne(o => o.User).WithMany().HasForeignKey(o => o.UserId);

        }
    }
}