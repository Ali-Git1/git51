
using BigonWebUI.Models.Entities;
using BigonWebUI.Models.Entities.Blog;
using BigonWebUI.Models.Persistences.Configurations;
using BigonWebUI.Models.Shop;
using Microsoft.EntityFrameworkCore;

namespace BigonWebUI.Models
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //modelBuilder.ApplyConfiguration<Color>(new ColorEntityConfiguration());    //her defe elave model olduqca bu kod tekrarlanacaq ve bunuda qisaltmaq mumkundur
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);  //bu datacontexde bunun oldugu assemblyde ne qeder configuration varsa islet

        }
        public DbSet<Color> Colors { get; set; }
        public DbSet<Tag> Tags { get; set; }

        public DbSet<Manufacture> Manufactures { get; set; }
        public DbSet<Subscriber> Subscribers { get; set; }

    }
}
