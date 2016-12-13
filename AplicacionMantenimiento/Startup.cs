using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AplicacionMantenimiento.Startup))]
namespace AplicacionMantenimiento
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
