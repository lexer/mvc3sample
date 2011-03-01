

namespace Web.Installers
{
    using System.Web.Mvc;

    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;

    using Controllers;
     

    public class ControllersInstaller : IWindsorInstaller
	{
		#region IWindsorInstaller Members

		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly()
			                   	.BasedOn<IController>()
                                .If(Component.IsInSameNamespaceAs<ProductsController>())
			                   	.If(t => t.Name.EndsWith("Controller"))
			                   	.Configure((c => c.LifeStyle.Transient)));
		}

		#endregion
	}
}