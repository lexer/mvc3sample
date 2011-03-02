using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Web.Installers
{
    using AutoMapper;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Models;

    using Repositories;

    using Services;

    public class AutoMapperInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
		    container.Register(
		        Component.For<IMappingEngine>().UsingFactoryMethod(
		            () =>
		            Mapper.Engine));

		    container.Register(AllTypes.FromThisAssembly().Where(Component.IsInSameNamespaceAs<ProductProfile>()));

		}

        #endregion
	}
}