using Khayati.Infrastructure.DatabaseSeeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            #region Seed Database
            CustomerSeed.DataSeed(modelBuilder);
            EmbellishmentTypeSeed.DataSeed(modelBuilder);
            EmbellishmentSeed.DataSeed(modelBuilder);
            #endregion
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<OrderDesign> OrderDesigns { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Embellishment> Embellishment { get; set; }
        public DbSet<EmbellishmentType> EmbellishmentTypes { get; set; }
    }
}
