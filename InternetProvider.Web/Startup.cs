using System.Reflection;
using System.Web.Mvc;
using Castle.MicroKernel.Lifestyle;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using InternetProvider.Data;
using InternetProvider.Data.Repositories;
using InternetProvider.Logic.DTO;
using InternetProvider.Logic.Interfaces;
using InternetProvider.Logic.Services;
using InternetProvider.Web.Infrastructure;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(InternetProvider.Web.Startup))]
namespace InternetProvider.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.CreatePerOwinContext(BootstrapContainer().BeginScope);
        }
        private IWindsorContainer BootstrapContainer()
        {
            var container = new WindsorContainer();
            container.Install(new AutoMapperInstaller());
            container.Register(Component.For<InetContext>().LifestyleScoped(),
            Classes.FromAssembly(Assembly.GetAssembly(typeof(ServiceRepository))).InSameNamespaceAs<ServiceRepository>().WithService.DefaultInterfaces().LifestyleTransient(),
            Classes.FromAssembly(Assembly.GetAssembly(typeof(AccountService))).InSameNamespaceAs<AccountService>().WithService.DefaultInterfaces().LifestyleTransient(),
            Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
            return container;
        }
    }
}
