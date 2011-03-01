namespace Web.Installers
{
	using Castle.MicroKernel.Registration;
	using Castle.MicroKernel.SubSystems.Configuration;
	using Castle.Windsor;

	using Web.Repositories;

	public class RepositoriesInstaller:IWindsorInstaller
	{
		public void Install(IWindsorContainer container, IConfigurationStore store)
		{
			container.Register(AllTypes.FromThisAssembly()
								.Where(Component.IsInSameNamespaceAs<CategoryRepository>())
								.WithService.DefaultInterface()
								.Configure(c => c.LifeStyle.Transient
			                   					.DependsOn(new { pageSize = 20 })));
		}
	}
}