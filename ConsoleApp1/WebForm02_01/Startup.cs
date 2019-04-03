using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WebForm02_01.Startup))]
namespace WebForm02_01
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
