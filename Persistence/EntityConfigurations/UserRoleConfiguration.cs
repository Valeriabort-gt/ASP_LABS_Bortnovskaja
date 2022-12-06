using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.Role).HasMaxLength(20).IsRequired();
        }
    }
}
