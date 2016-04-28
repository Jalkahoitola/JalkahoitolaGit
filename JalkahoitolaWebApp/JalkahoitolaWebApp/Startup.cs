using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(JalkahoitolaWebApp.Startup))]
namespace JalkahoitolaWebApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
