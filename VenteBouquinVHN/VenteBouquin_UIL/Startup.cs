using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VenteBouquin_UIL.Startup))]
namespace VenteBouquin_UIL
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
