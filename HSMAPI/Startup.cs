using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(HSMAPI.Startup))]
namespace HSMAPI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
