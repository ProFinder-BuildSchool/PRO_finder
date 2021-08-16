using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PRO_finder.Startup))]
namespace PRO_finder
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }

        
    }
}
