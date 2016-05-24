using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PointAjanvarausMVC.Startup))]
namespace PointAjanvarausMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
