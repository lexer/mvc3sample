using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Installers
{
    using System.Web.Mvc;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Plumbing;

    public class WindsorDependencyResolverInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDependencyResolver>().ImplementedBy<WindsorDependencyResolver>());
        }
    }
}