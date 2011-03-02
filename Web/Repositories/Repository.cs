namespace Web.Repositories
{
    using System;
    using System.Collections.Generic;

    using Domain;

    using NHibernate;

    public class Repository<T> : IRepository<T>
        where T : EntityBase
    {
        private readonly Func<ISession> sessionFunc;

        public Repository(Func<ISession> sessionFunc)
        {
            this.sessionFunc = sessionFunc;
        }

        #region IRepository<T> Members

        public IEnumerable<T> All()
        {
            ISession session = this.GetSession();
            using (ITransaction tx = session.BeginTransaction())
            {
                IEnumerable<T> result = session.QueryOver<T>().Future();
                tx.Commit();
                return result;
            }
        }

        protected ISession GetSession() 
        {
            return this.sessionFunc();
        }

        public void Save(T entity)
        {
            ISession session = this.GetSession();
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Save(entity);
                tx.Commit();
            }
        }

        public T Find(int id)
        {
            ISession session = this.GetSession();
            using (ITransaction tx = session.BeginTransaction())
            {
                var result = session.Get<T>(id);
                tx.Commit();
                return result;
            }
        }

        public void Update(T entity)
        {
            ISession session = this.GetSession();
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Update(entity);
                tx.Commit();
            }
        }

        public void Delete(T entity)
        {
            ISession session = this.GetSession();
            using (ITransaction tx = session.BeginTransaction())
            {
                session.Delete(entity);
                tx.Commit();
            }
        }

        #endregion

       
    }
}