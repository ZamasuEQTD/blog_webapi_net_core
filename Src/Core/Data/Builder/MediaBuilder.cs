using Medias.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data
{
    public class MediaConfiguration : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Id).HasConversion(id => id.Value, value => new MediaId(value));
            builder.Property(m => m.Hash);
            builder.Property(m => m.Url);
        }
    }
    public class MediaReferenceConfiguration : IEntityTypeConfiguration<MediaReference>
    {
        public void Configure(EntityTypeBuilder<MediaReference> builder)
        {
            builder.HasKey(mr => mr.Id);
            builder.Property(mr => mr.Id).HasConversion(id => id.Value, value => new MediaReferenceId(value));
            builder.Property(mr => mr.EsSpoiler);
            builder.HasOne(mr => mr.Media).WithMany().HasForeignKey(mr => mr.MediaId).IsRequired();

        }
    }
}