using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Hairstudio_MVC.Startup))]
namespace Hairstudio_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
