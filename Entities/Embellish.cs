namespace Entities
{
    public  class Embellish
    {
        public int EmbellishId { get; set; }

        public string EmbelishName { get; set; }

        public int? EmbellishTypeId { get; set; }


        public virtual EmbellishType? EmbellishType { get; set; }

        //public virtual ICollection<OrderEmbellish>? OrderEmbellishes { get; set; }
    }
}
