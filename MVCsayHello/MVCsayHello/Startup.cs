using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCsayHello.Startup))]
namespace MVCsayHello
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
