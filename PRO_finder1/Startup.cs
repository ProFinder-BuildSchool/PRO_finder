using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRO_finder1.Startup))]
namespace PRO_finder1
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
