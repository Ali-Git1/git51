using BigonWebUI.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BigonWebUI.Models.Persistences.Configurations
{
    public class ColorEntityConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.HasKey(m => m.Id);



            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(20).IsRequired();
            builder.Property(m => m.HexCode).HasColumnType("varchar").HasMaxLength(7).IsRequired();


            builder.ConfigurAsAuditable();

            builder.ToTable("Colors"); //burada ne ad yazilsa birbasa table yaradanda bu adda yaradacaq










        }
    }
}
