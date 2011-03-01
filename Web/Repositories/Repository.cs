namespace Web.Repositories
{
    using System.Collections.Generic;

    using Domain;

    using NHibernate;

    public class Repository<T> : IRepository<T>
        where T:EntityBase
    {
        private readonly ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        public IEnumerable<T> GetAll()
        {
            return this.session.QueryOver<T>().Future();
        }

        public void Save(T entity)
        {
            using (ITransaction tx = this.session.BeginTransaction())
            {
                this.session.Save(entity);
                tx.Commit();
            }
        }

        protected ISession GetSession()
        {
            return this.session;
        }
    }
}