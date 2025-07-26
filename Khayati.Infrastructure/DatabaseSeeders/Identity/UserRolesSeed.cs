using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Infrastructure.DatabaseSeeders.Identity
{
    public static class UserRolesSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(
                new IdentityUserRole<int>
                {
                    UserId = 1, // adminuser
                    RoleId = 1  // SD.Role_Admin
                },
                new IdentityUserRole<int>
                {
                    UserId = 2, // administratoruser
                    RoleId = 2  // SD.Role_Administrator
                },
                new IdentityUserRole<int>
                {
                    UserId = 3, // employeeuser
                    RoleId = 3  // SD.Role_Employee
                });
        }
    }

}
