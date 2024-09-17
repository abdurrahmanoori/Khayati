namespace Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerAddress { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Measurement> Measurements { get; set; }


    }
}
