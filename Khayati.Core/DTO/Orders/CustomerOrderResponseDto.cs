namespace Khayati.Core.DTO.Orders
{
    public class CustomerOrderResponseDto
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }
        public string? LastName { get; set; }

        public int OrderId { get; set; }
        public decimal? TotalCost { get; set; }
        public DateTime OrderDate { get; set; }
        public bool IsPaid { get; set; }
    }
}
