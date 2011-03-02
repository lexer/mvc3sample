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
		    container.Register(Component.For<IMappingEngine>().UsingFactoryMethod(()=>
                Mapper.Engine));
		   
            container.Register(AllTypes.FromThisAssembly().Where(Component.IsInSameNamespaceAs<ProductProfile>()));
            
            Mapper.Initialize(x => GetProfiles().ToList().ForEach(type => x.AddProfile((Profile) container.Resolve(type))));
            Mapper.AssertConfigurationIsValid();

		}

        private static IEnumerable<Type> GetProfiles()
        {
            foreach (Type type in typeof (ProductProfile).Assembly.GetTypes())
            {
                if (!type.IsAbstract && typeof (Profile).IsAssignableFrom(type))
                    yield return type;
            }
        }

		#endregion
	}
}