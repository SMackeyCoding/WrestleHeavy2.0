using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WrestleHeavy.MVC.Startup))]
namespace WrestleHeavy.MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
