using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class RentConfiguration : IEntityTypeConfiguration<Rent>
    {
        public void Configure(EntityTypeBuilder<Rent> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.entryDate).IsRequired(true);
            builder.Property(note => note.roomID).IsRequired(true);
            builder.Property(note => note.organizationID).IsRequired(true);
            builder.Property(note => note.exitDate).IsRequired(true);
        }
    }
}
