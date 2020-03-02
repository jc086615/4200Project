using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_4200Project.Startup))]
namespace _4200Project
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
