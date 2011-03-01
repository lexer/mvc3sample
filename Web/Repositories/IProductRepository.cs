namespace Web.Repositories
{
    using System.Collections.Generic;

    using Domain;

    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();

        void Save(Product product);
    }
}