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
         public DbSet<Design> Designs { get; set; } 
         public DbSet<Orders> Orders { get; set; } 
         public DbSet<Emblish> Embellish { get; set; } 
         public DbSet<EmblishType> EmbellishTypes { get; set; } 
    }
}
