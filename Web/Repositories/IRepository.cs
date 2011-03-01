namespace Web.Repositories
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IEnumerable<T> GetAll();

        void Save(T entity);
    }
}