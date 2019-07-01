using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using InternetProvider.Data.Repositories;
using InternetProvider.Logic.Interfaces;
using InternetProvider.Logic.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;

namespace InternetProvider.Web.Infrastructure
{
    public class BusinessLogicInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IUnitOfWork>().ImplementedBy<UnitOfWork>().DependsOn(new { connString = ConfigurationManager.ConnectionStrings["InternetProviderDb"].ConnectionString }));
            container.Register(
                Classes.FromAssembly(Assembly.GetAssembly(typeof(UserRepository))).InSameNamespaceAs<UserRepository>().WithService.DefaultInterfaces().LifestyleTransient(),
                Classes.FromAssembly(Assembly.GetAssembly(typeof(UserService))).InSameNamespaceAs<UserService>().WithService.DefaultInterfaces().LifestyleTransient()
            );

        }
    }
}