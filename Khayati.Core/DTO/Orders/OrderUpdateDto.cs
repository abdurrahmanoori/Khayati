using Khayati.Core.DTO.Customers;
using Khayati.Core.DTO.OrderGarments;
using Khayati.Core.DTO.payment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khayati.Core.DTO.Orders
{
    public  class OrderUpdateDto
    {
        public DateTime? ExpectedCompletionDate { get; set; }
        public decimal? Cost { get; set; }
        public decimal? TotalCost { get; set; }
        public bool IsPaid { get; set; }
        public string? Notes { get; set; }
        public string OrderStatus { get; set; }
        public string PaymentStatus { get; set; }
        public string OrderPriority { get; set; }
        public List<PaymentDto>? Payments { get; set; }
        public List<OrderGarmentDto>? OrderGarments { get; set; }

    }
}
