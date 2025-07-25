﻿using Entities;
using Entities.Enum;
using Khayati.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khayati.Core.Domain.Entities;
namespace Khayati.Core.DTO
{
    public class OrdersResponseDto
    {
        public int OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public decimal? TotalCost { get; set; }
        public OrderStatus OrderStatus { get; set; }

        public PaymentStatus PaymentStatus { get; set; }

        public OrderPriority OrderPriority { get; set; }
        public Customer? Customer { get; set; }
        public ICollection<Payment>? Payments { get; set; }
        public List<OrderGarment>? OrderGarments { get; set; }
    }
}
