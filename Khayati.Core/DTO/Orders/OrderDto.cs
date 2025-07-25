﻿
using Entities.Enum;
using Khayati.Core.DTO.Customers;
using Khayati.Core.DTO.OrderGarments;
using Khayati.Core.DTO.payment;
using Khayati.Core.Enums;

namespace Khayati.Core.DTO.Orders
{
    public class OrderDto
    {
        public int? OrderId { get; set; }
        public int CustomerId { get; set; }
        public DateTime? ExpectedCompletionDate { get; set; }
        public decimal? Cost { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
        public string? Notes { get; set; }

        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderPriority { get; set; }
        public CustomerResponseDto? Customer { get; set; }
        public List<PaymentDto>? Payments { get; set; }
        public List<OrderGarmentDto>? OrderGarments { get; set; }


    }
}
