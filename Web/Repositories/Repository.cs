namespace Web.Repositories
{
    using System.Collections.Generic;

    using Domain;

    using NHibernate;

    public class Repository<T> : IRepository<T>
        where T : EntityBase
    {
        private readonly ISession session;

        public Repository(ISession session)
        {
            this.session = session;
        }

        #region IRepository<T> Members

        public IEnumerable<T> All()
        {
            using (ITransaction tx = this.session.BeginTransaction())
            {
                var result = this.session.QueryOver<T>().Future();
                tx.Commit();
                return result;
            }
        }

        public void Save(T entity)
        {
            using (ITransaction tx = this.session.BeginTransaction())
            {
                this.session.Save(entity);
                tx.Commit();
            }
        }

        public T Find(int id)
        {
            using (ITransaction tx = this.session.BeginTransaction())
            {
                var result = this.session.Get<T>(id);
                tx.Commit();
                return result;
            }
        }

        public void Update(T entity)
        {
            using (ITransaction tx = this.session.BeginTransaction())
            {
                this.session.Update(entity);
                tx.Commit();
            }
        }

        public void Delete(T entity)
        {
            using (ITransaction tx = this.session.BeginTransaction())
            {
                this.session.Delete(entity);
                tx.Commit();
            }
        }

        #endregion

        protected ISession GetSession()
        {
            return this.session;
        }
    }
}