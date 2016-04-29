using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PointJalkahoitolaMVC.Startup))]
namespace PointJalkahoitolaMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
