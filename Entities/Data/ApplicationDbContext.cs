using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) 
        {

        }
         public DbSet<Customer> Customers { get; set; } 
         public DbSet<Measurement> Measurements { get; set; } 
         public DbSet<OrderDesign> OrderDesigns { get; set; } 
         public DbSet<Order> Orders { get; set; } 
         public DbSet<Embellishmentment> Embellishment { get; set; } 
         public DbSet<EmbellishmentmentType> EmbellishmentTypes { get; set; } 
    }
}
