using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebAppHack.Startup))]
namespace WebAppHack
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
