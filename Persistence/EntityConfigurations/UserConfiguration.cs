using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.Login).HasMaxLength(100).IsRequired();
            builder.Property(note => note.Password).HasMaxLength(100).IsRequired();
            builder.Property(note => note.RoleId).IsRequired();
        }
    }
}
