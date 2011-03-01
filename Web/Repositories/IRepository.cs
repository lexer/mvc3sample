namespace Web.Repositories
{
    using System.Collections.Generic;

    public interface IRepository<T>
    {
        IEnumerable<T> All();

        void Save(T entity);

        T Find(int id);

        void Update(T entity);

        void Delete(T entity);
    }
}