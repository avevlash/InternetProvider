using Castle.Facilities.Logging;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Services.Logging.Log4netIntegration;
using Castle.Windsor;
using log4net.Config;
using log4net.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: XmlConfigurator(Watch = true)]
namespace InternetProvider.Web.Infrastructure
{
    public class LoggerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            XmlConfigurator.Configure();
            container.AddFacility<LoggingFacility>(f => f.LogUsing<Log4netFactory>());
        }
    }
}