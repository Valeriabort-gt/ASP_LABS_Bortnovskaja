using Microsoft.EntityFrameworkCore;
using Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigurations
{
    public class InvoiceConfiguration : IEntityTypeConfiguration<Invoice>
    {
        public void Configure(EntityTypeBuilder<Invoice> builder)
        {
            builder.HasKey(note => note.id);
            builder.HasIndex(note => note.id).IsUnique();
            builder.Property(note => note.createDate).IsRequired(true);
            builder.Property(note => note.number).HasMaxLength(20).IsRequired(true);
            builder.Property(note => note.organizationID).IsRequired(true);
            builder.Property(note => note.roomID).IsRequired(true);
            builder.Property(note => note.puySum).IsRequired(true);
            builder.Property(note => note.payDate).IsRequired(true);
            builder.Property(note => note.employeeID).IsRequired(true);
        }
    }
}
