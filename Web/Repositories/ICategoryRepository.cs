namespace Web.Repositories
{
    using System.Collections.Generic;

    using Domain;

    public interface ICategoryRepository
    {
        IEnumerable<Category> GetAll();
    }
}