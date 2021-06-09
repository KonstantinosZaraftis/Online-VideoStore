using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Vindly1.Startup))]
namespace Vindly1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
