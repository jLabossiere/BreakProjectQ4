using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BreakProjectWebApp.Startup))]
namespace BreakProjectWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
