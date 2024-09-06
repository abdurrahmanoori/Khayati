namespace Entities
{
    public class EmbellishType
    {
        public int  EmbelishTypeId { get; set; }

        public string EmbelishTypeName { get;set; }


        public virtual ICollection<Embellish>? Embellishes { get; set; }

    }
}
