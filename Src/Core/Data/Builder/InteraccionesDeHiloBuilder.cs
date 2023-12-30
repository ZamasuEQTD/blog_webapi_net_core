
using InteraccionesDeHilo.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class InteraccionesDeHiloConfiguration : IEntityTypeConfiguration<InteraccionDeHilo>
    {
        public void Configure(EntityTypeBuilder<InteraccionDeHilo> builder)
        {
            builder.HasKey(h => h.Id);
            builder.Property(h => h.Id).HasConversion(id => id.Value, value => new InteraccionDeHiloId(value));
            builder.HasOne(i => i.Hilo).WithMany().HasForeignKey(i => i.HiloId).IsRequired();
            builder.Property(i => i.Favorito);
            builder.Property(i => i.Oculto);
            builder.Property(i => i.Siguiendo);

        }
    }
}