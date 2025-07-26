using Khayati.Core.Utility;
using Khayati.Infrastructure.Identity.Entity;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Infrastructure.DatabaseSeeders.Identity
{
    public static class ApplicationRoleSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApplicationRole>().HasData(
                new ApplicationRole
                {
                    Id = 1,
                    Name = SD.Role_Admin,
                    NormalizedName = SD.Role_Admin.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new ApplicationRole
                {
                    Id = 2,
                    Name = SD.Role_Administrator,
                    NormalizedName = SD.Role_Administrator.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },

                new ApplicationRole
                {
                    Id = 3,
                    Name = SD.Role_Employee,
                    NormalizedName = SD.Role_Employee.ToUpper(),
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                });
        }
    }
}
