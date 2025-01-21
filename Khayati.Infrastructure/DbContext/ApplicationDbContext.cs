using Khayati.Core.Common;
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
        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker.Entries<AuditableEntity>();
            int? currentUserId = 1;// Convert.ToInt32(_httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier));
            //_httpContextAccessor.HttpContext?.User?.Identity?.Name ?? "System"; // Replace with your user logic

            foreach (var entry in entries)
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.UtcNow;
                        entry.Entity.CreatedBy = currentUserId;
                        break;

                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.UtcNow;
                        entry.Entity.UpdatedBy = currentUserId;
                        break;

                    case EntityState.Deleted:
                        entry.State = EntityState.Modified; // Soft-delete the entity
                        entry.Entity.IsDeleted = true;
                        entry.Entity.DeletedAt = DateTime.UtcNow;
                        entry.Entity.DeletedBy = currentUserId;
                        break;
                }
            }

            return base.SaveChangesAsync(cancellationToken);
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
    }

}
