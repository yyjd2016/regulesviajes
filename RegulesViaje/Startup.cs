using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RegulesViaje.Startup))]
namespace RegulesViaje
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
