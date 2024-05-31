using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using BigonWebUI.Models.Entities;

namespace BigonWebUI.Models.Persistences.Configurations
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        { 
            builder.HasKey(m => m.Id);



            builder.Property(m => m.Id).HasColumnType("int");
            builder.Property(m => m.Name).HasColumnType("varchar").HasMaxLength(50).IsRequired();




            builder.HasOne<Category>().WithMany().HasForeignKey(m => m.ParentId).HasPrincipalKey(m => m.Id).OnDelete(DeleteBehavior.NoAction);


            builder.ConfigurAsAuditable();

            builder.ToTable("Category"); //burada ne ad yazilsa birbasa table yaradanda bu adda yaradacaq










        }

        
    }
}
