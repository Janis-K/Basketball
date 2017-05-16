using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Basketball.Web.Startup))]
namespace Basketball.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
