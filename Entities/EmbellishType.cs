namespace Entities
{
    public class EmbellishType
    {
        public int  EmbellishTypeId { get; set; }

        public string EmbellishTypeName { get;set; }


        public virtual ICollection<Embellish>? Embellishes { get; set; }

    }
}
