namespace Web.Repositories
{
    using Domain;

    using NHibernate;

    public class ProductRepository :Repository<Product>, IProductRepository 
    {
        public ProductRepository(ISession session)
            : base(session)
        {
        }
    }
}