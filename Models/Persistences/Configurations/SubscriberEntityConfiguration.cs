using BigonWebUI.Models.Entities;
using BigonWebUI.Models.Shop;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonWebUI.Models.Persistences.Configurations
{
    public class SubscriberEntityConfiguration : IEntityTypeConfiguration<Subscriber>
    {
        public void Configure(EntityTypeBuilder<Subscriber> builder)
        {
            builder.Property(m => m.EmailAddress).HasColumnType("varchar").HasMaxLength(100);
            builder.Property(m => m.IsApproved).HasColumnType("bit");
            builder.Property(m => m.ApprovedAt).HasColumnType("datetime");
            builder.Property(m => m.CreatedAt).HasColumnType("datetime").IsRequired();




            builder.HasKey(m=> m.EmailAddress);

            builder.ToTable("Subscribers");
        }
    }
}
