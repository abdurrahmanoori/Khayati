using Khayati.Infrastructure.Identity.Entity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Khayati.Infrastructure.DatabaseSeeders.Identity
{
    public static class ApplicationUserSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var user1 = new ApplicationUser
            {
                Id = 1,
                UserName = "adminuser",
                NormalizedUserName = "ADMINUSER",
                Email = "admin@example.com",
                NormalizedEmail = "ADMIN@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            user1.PasswordHash = hasher.HashPassword(user1, "adminuser");

            var user2 = new ApplicationUser
            {
                Id = 2,
                UserName = "administratoruser",
                NormalizedUserName = "ADMINISTRATORUSER",
                Email = "administrator@example.com",
                NormalizedEmail = "ADMINISTRATOR@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            user1.PasswordHash = hasher.HashPassword(user1, "administratoruser");

            var user3 = new ApplicationUser
            {
                Id = 3,
                UserName = "employeeuser",
                NormalizedUserName = "EMPLOYEEUSER",
                Email = "employee@example.com",
                NormalizedEmail = "EMPLOYEE@EXAMPLE.COM",
                EmailConfirmed = true,
                SecurityStamp = Guid.NewGuid().ToString(),
                ConcurrencyStamp = Guid.NewGuid().ToString()
            };
            user2.PasswordHash = hasher.HashPassword(user2, "employeeuser");

            modelBuilder.Entity<ApplicationUser>().HasData(user1, user2, user3);
        }
    }

}
