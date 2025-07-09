using Khayati.Core.Domain.Entities;
using Khayati.Core.Domain.UserServiceContracts;
using Khayati.Infrastructure.DatabaseSeeders;
using Khayati.Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Entities.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        //private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUser _currentUser;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentUser currentUser)
            : base(options)
        {
            _currentUser = currentUser;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Order>()
                .Property(x => x.OrderStatus)
                .HasConversion<string>();

            modelBuilder.Entity<Order>()
                .Property(x => x.PaymentStatus)
                .HasConversion<string>();

            modelBuilder.Entity<Order>()
                .Property(x => x.OrderPriority)
                .HasConversion<string>();



            #region Seed Database
            CustomerSeed.DataSeed(modelBuilder);
            EmbellishmentTypeSeed.DataSeed(modelBuilder);
            Embellishmenteed.DataSeed(modelBuilder);
            FabricSeed.DataSeed(modelBuilder);
            //MeasurmentSeed.DataSeed(modelBuilder);
            #endregion

            #region Fluent Configuration
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            //modelBuilder.ApplyConfiguration(new PaymentConfiguration());

            modelBuilder.Entity<EmbellishmentType>()
                .HasIndex(e => e.Name)
                .IsUnique();

            #endregion

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Measurement> Measurements { get; set; }
        public DbSet<OrderDesign> OrderDesigns { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Embellishment> Embellishment { get; set; }
        public DbSet<EmbellishmentType> EmbellishmentTypes { get; set; }
        public DbSet<Translation> Translations { get; set; }
        public DbSet<Fabric> Fabrics { get; set; }
        public DbSet<Garment> Garments { get; set; }
        public DbSet<GarmentField> GarmentFields { get; set; }
    }

}
