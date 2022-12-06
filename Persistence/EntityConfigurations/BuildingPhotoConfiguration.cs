using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class BuildingPhotoConfiguration : IEntityTypeConfiguration<BuildingPhoto>
    {
        public void Configure(EntityTypeBuilder<BuildingPhoto> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.photoID).IsRequired();
            builder.Property(note => note.buildingID).IsRequired();
        }
    }
}
