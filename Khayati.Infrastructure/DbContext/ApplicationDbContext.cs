﻿using Khayati.Core.Domain.Entities;
using Khayati.Infrastructure.DatabaseSeeders;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace Entities.Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHttpContextAccessor httpContextAccessor)
            : base(options)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Seed Database
            CustomerSeed.DataSeed(modelBuilder);
            EmbellishmentTypeSeed.DataSeed(modelBuilder);
            EmbellishmentSeed.DataSeed(modelBuilder);
            MeasurmentSeed.DataSeed(modelBuilder);
            #endregion

            #region Fluent Configuration
            modelBuilder.Entity<EmbellishmentType>()
                .HasIndex(e => e.EmbellishmentTypeName)
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
        public DbSet<Embellishment> Embellishment { get; set; }
        public DbSet<EmbellishmentType> EmbellishmentTypes { get; set; }
    }
}
