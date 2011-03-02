using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Plumbing
{
    using Castle.MicroKernel;

    public class WindsorDependencyResolver : System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public WindsorDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return kernel.Resolve(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.ResolveAll(serviceType).Cast<object>(); 
        }
    }
}