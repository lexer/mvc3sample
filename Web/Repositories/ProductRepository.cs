namespace Web.Repositories
{
    using System;
    using System.Collections.Generic;

    using Domain;

    using NHibernate;

    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Func<ISession> sessionFunc)
            : base(sessionFunc)
        {
            
        }

        public IEnumerable<Product> AllWithCategory()
        {
            ISession session = this.GetSession();
            using (ITransaction tx = session.BeginTransaction())
            {
                IEnumerable<Product> result = session.QueryOver<Product>().Fetch(r => r.Category).Eager.Future();
                tx.Commit();
                return result;
            }
        }
    }
}