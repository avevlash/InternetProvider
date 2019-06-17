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
            
        }
    }
}
