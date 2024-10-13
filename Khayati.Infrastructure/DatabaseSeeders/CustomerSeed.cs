using Entities;
using Microsoft.EntityFrameworkCore;

namespace Khayati.Infrastructure.DatabaseSeeders
{
    public static class CustomerSeed
    {
        public static void DataSeed(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   CustomerId = 1,
                   Name = "John Doe",
                   Address = "123 Main St, Springfield",
                   PhoneNumber = "123-456-7890",
                   EmailAddress = "johndoe@example.com",
                   NationalID = "1234567890",
                   DateOfBirth = new DateTime(1985, 1, 15),
                   //CustomerSince = new DateTime(2010, 5, 20),
                   //CustomerType = "Regular"
               },
            new Customer
            {
                CustomerId = 2,
                Name = "Jane Smith",
                Address = "456 Elm St, Springfield",
                PhoneNumber = "987-654-3210",
                EmailAddress = "janesmith@example.com",
                NationalID = "0987654321",
                DateOfBirth = new DateTime(1990, 3, 22),
                //CustomerSince = new DateTime(2015, 7, 18),
                //CustomerType = "VIP"
            },
            new Customer
            {
                CustomerId = 3,
                Name = "Robert Brown",
                Address = "789 Oak St, Metropolis",
                PhoneNumber = "555-123-4567",
                EmailAddress = "robertbrown@example.com",
                NationalID = "4567890123",
                DateOfBirth = new DateTime(1975, 9, 10),
                //CustomerSince = new DateTime(2008, 3, 25),
                //CustomerType = "Corporate"
            },
            new Customer
            {
                CustomerId = 4,
                Name = "Emily Davis",
                Address = "321 Pine St, Gotham",
                PhoneNumber = "321-654-9870",
                EmailAddress = "emilydavis@example.com",
                NationalID = "3216549870",
                DateOfBirth = new DateTime(1992, 11, 5),
                //CustomerSince = new DateTime(2017, 6, 12),
                //CustomerType = "Regular"
            },
            new Customer
            {
                CustomerId = 5,
                Name = "Michael Johnson",
                Address = "654 Maple St, Star City",
                PhoneNumber = "777-888-9999",
                EmailAddress = "michaeljohnson@example.com",
                NationalID = "9876543210",
                DateOfBirth = new DateTime(1980, 7, 30),
                //CustomerSince = new DateTime(2005, 1, 3),
                //CustomerType = "VIP"
            }
        );
        }
    }
}
