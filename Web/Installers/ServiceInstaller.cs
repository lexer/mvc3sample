
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Web.Services;


namespace Web.Installers
{
    using Castle.MicroKernel.Registration;
    using NHibernate.Mapping;


    public class ServiceInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly().Pick()
			                   	.If(Castle.MicroKernel.Registration.Component.IsInSameNamespaceAs<CategoryService>())
			                   	.Configure(c => c.LifeStyle.Transient)
			                   	.WithService.DefaultInterface());
		}

		#endregion
	}
}