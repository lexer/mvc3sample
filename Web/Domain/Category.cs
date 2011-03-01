namespace Web.Domain
{
    using System.Collections.Generic;

    public class Category: EntityBase
    {
        public virtual string Name { get; set; }
        public virtual IList<Product> Products { get; private set; }

        public Category()
        {
            this.Products = new List<Product>();
        }
    }
}