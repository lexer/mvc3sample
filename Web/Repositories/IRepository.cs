namespace Web.Repositories
{
    using System.Collections.Generic;

    using Domain;

    using FluentNHibernate.Data;

    public interface IRepository<T>
    {
        IEnumerable<T> All();

        void Save(T entity);

        T Find(int id);

        void Update(T entity);

        void Delete(T entity);
    }

    public interface IRepository
    {
        EntityBase Find(int id);
    }

}