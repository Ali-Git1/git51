using BigonWebUI.Models.Entities.Blog;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BigonWebUI.Models.Shop;

namespace BigonWebUI.Models.Persistences.Configurations
{
    public class ManufactureEntityConfiguration : IEntityTypeConfiguration<Manufacture>
    {
        public void Configure(EntityTypeBuilder<Manufacture> builder)
        {
            builder.HasKey(m => m.Id);



            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.BrandOne).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(m => m.BrandTwo).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(m => m.BrandThree).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(m => m.BrandFour).HasColumnType("varchar").HasMaxLength(30).IsRequired();
            builder.Property(m => m.BrandFive).HasColumnType("varchar").HasMaxLength(30).IsRequired();




            builder.ConfigurAsAuditable(); //configuration helperde yazilanlari cagirmaq ucun yaziriq

            builder.ToTable("Manufacture"); //burada ne ad yazilsa birbasa table yaradanda bu adda yaradacaq
        }
    }
}
