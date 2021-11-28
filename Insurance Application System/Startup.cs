using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Insurance_Application_System.Startup))]
namespace Insurance_Application_System
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
