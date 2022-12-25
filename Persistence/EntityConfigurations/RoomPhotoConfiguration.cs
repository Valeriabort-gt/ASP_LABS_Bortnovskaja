using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class RoomPhotoConfiguration : IEntityTypeConfiguration<RoomPhoto>
    {
        public void Configure(EntityTypeBuilder<RoomPhoto> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.roomID).IsRequired();
            builder.Property(note => note.photoID).IsRequired();
        }
    }
}
