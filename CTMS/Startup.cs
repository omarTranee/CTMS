using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CTMS.Startup))]
namespace CTMS
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
