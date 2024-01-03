using Auth.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Users.Domain;

namespace Data
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Id).HasConversion(id => id.Value, value => new UserId(value)).IsRequired().ValueGeneratedOnAdd();
            builder.ComplexProperty(u => u.UserName);
            builder.ComplexProperty(u => u.Password);
        }
    }
}