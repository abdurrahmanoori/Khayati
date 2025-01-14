using Bogus;
using Khayati.Core.DTO;
using Khayati.Core.DTO.Measurement;

namespace Khayati.Mvc.DataGenerators
{
    public class DataGenerator
    {
        // CustomerAddDto Data Generator
        public static CustomerAddDto GenerateCustomer( )
        {
            var customerFaker = new Faker<CustomerAddDto>()
                .RuleFor(c => c.Name, f => f.Name.FullName())
                .RuleFor(c => c.Address, f => f.Address.FullAddress())
                .RuleFor(c => c.PhoneNumber, f => f.Phone.PhoneNumber())
                .RuleFor(c => c.EmailAddress, f => f.Internet.Email())
                .RuleFor(c => c.NationalID, f => f.Random.Replace("#####-######-###"))
                .RuleFor(c => c.DateOfBirth, f => f.Date.Past(30, DateTime.Now.AddYears(-18)))
                .RuleFor(c => c.CustomerSince, f => f.Date.Past(5))
                .RuleFor(c => c.CustomerType, f => f.PickRandom(new[] { "Regular", "Premium", "VIP" }));

            return customerFaker.Generate();
        }

        // MeasurementAddDto Data Generator
        public static MeasurementAddDto GenerateMeasurement()
        {
            var measurementFaker = new Faker<MeasurementAddDto>()
                //.RuleFor(m => m.CustomerId, _ => customerId)
                .RuleFor(m => m.Height, f => f.Random.Double(150, 200))       // cm
                .RuleFor(m => m.Chest, f => f.Random.Double(80, 120))         // cm
                .RuleFor(m => m.Waist, f => f.Random.Double(70, 110))         // cm
                .RuleFor(m => m.Leg, f => f.Random.Double(80, 120))           // cm
                .RuleFor(m => m.trousers, f => f.Random.Double(30, 50))       // cm
                .RuleFor(m => m.Neck, f => f.Random.Double(30, 50))           // cm
                .RuleFor(m => m.Sleeve, f => f.Random.Double(50, 70))         // cm
                .RuleFor(m => m.DateCreated, f => f.Date.Recent().ToOADate())
                //.RuleFor(m => m.DateTaken, f => f.Date.Past().ToOADate())
                .RuleFor(m => m.ShoulderWidth, f => f.Random.Double(35, 55))  // cm
                .RuleFor(m => m.ArmLength, f => f.Random.Double(50, 70));     // cm

            return measurementFaker.Generate();
        }

        // OrdersAddDto Data Generator
        public static OrdersAddDto GenerateOrder()
        {
            var orderFaker = new Faker<OrdersAddDto>()
                //.RuleFor(o => o.CustomerId, _ => customerId)
                .RuleFor(o => o.OrderDate, f => f.Date.Past(1))
                .RuleFor(o => o.ExpectedCompletionDate, f => f.Date.Future(1))
                //.RuleFor(o => o.TotalCost, f => f.Finance.Amount(100, 10000))
                .RuleFor(o => o.Status, f => f.PickRandom(new[] { "Pending"}));
                //.RuleFor(o => o.Status, f => f.PickRandom(new[] { "Pending", "Processing", "Completed", "Cancelled" }));

            return orderFaker.Generate();
        }

    }
}
