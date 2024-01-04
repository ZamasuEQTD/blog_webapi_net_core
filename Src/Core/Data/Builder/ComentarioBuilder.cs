using Comentarios.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
     public class ComentarioConfiguration : IEntityTypeConfiguration<Comentario>
    {
        public void Configure(EntityTypeBuilder<Comentario> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(id => id.Value, value => new ComentarioId(value));
            builder.Property(c=> c.CreatedAt);
            builder.HasOne(c=> c.Autor).WithMany().HasForeignKey(c=> c.AutorId).IsRequired();
            builder.HasOne(c=> c.Hilo).WithMany().HasForeignKey(c=> c.HiloId);
            builder.HasOne(c=> c.Media).WithMany().HasForeignKey(c=> c.MediaId);
            builder.ComplexProperty(c => c.DatosDeComentario)
            .ComplexProperty(d=> d.Tag);
            builder.ComplexProperty(c => c.DatosDeComentario).Property(d=> d.TagUnico).HasConversion(id => id.Value, value =>  TagUnico.Create(value).Value).IsRequired(false);
            builder.ComplexProperty(c => c.Texto);

        }
    }
}