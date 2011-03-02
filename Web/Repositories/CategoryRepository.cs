using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Repositories
{
    using Domain;

    using NHibernate;

    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        public CategoryRepository(Func<ISession> sessionFunc)
            : base(sessionFunc)
        {
        }

    }
}