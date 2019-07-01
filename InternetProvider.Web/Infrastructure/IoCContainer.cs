using Castle.Core;
using Castle.MicroKernel;
using Castle.MicroKernel.Context;
using Castle.Windsor;
using Castle.Windsor.Installer;
using InternetProvider.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InternetProvider.Web.Infrastructure
{
    public static class IoCContainer
    {
        private static IWindsorContainer _container;

        public static void Setup()
        {
            _container = new WindsorContainer();
            _container.Install(FromAssembly.This());
            _container.Kernel.Resolver.AddSubResolver(new ConnectionStringConventions());
            //_container.BeginScope();
            WindsorControllerFactory controllerFactory = new WindsorControllerFactory(_container.Kernel);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);

        }
    }
          
    public class ConnectionStringConventions : ISubDependencyResolver
    {
        public bool CanResolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            return dependency.TargetType == typeof(string)
                && dependency.DependencyKey.EndsWith("connString");
        }

        public object Resolve(
            CreationContext context,
            ISubDependencyResolver contextHandlerResolver,
            ComponentModel model,
            DependencyModel dependency)
        {
            var name = dependency.DependencyKey.Replace("connString", "InternetProviderDb");
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }
    }
}