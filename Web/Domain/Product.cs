namespace Web.Domain
{
    public class Product : EntityBase
    {
        public virtual string Name { get; set; }

        public virtual decimal Price { get; set; }

        public virtual Category Category { get; set; }

        public virtual string Description { get; set; }
    }
}