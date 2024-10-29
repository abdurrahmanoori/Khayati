using AutoFixture;
using Khayati.Core.DTO;
using Khayati.Mvc.Areas.Customer.Controllers;
using Khayati.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khyati.Test.Services
{
    public  class Seeder
    {
        private readonly Fixture _fixture;
        private readonly OrderController _orderController;
        private readonly IOrdersService _ordersService;

        public Seeder(IOrdersService ordersService)
        {
            _ordersService = ordersService;

            _orderController = new OrderController(_ordersService);
            _fixture = new Fixture();
        }

        [Fact]
        public void Seed( )
        {
            // Arrange
            var customer = _fixture.Build<CustomerAddDto>()
                .Create();
            var measurment = _fixture.Build<MeasurementAddDto>().Create();

            var order = _fixture.Build<OrdersAddDto>().Create();
            //_orderController.Create(customer,measurment,order);
            


            //Act 


        }
    }
}
