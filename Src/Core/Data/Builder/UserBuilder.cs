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
            builder.Property(u => u.UserName).HasConversion(nombre => nombre.Value, value => UserName.Create(value).Value!);
            builder.Property(u => u.Password).HasConversion(Password => Password.Value, value => new HashedPassword(value));
        }
    }
}