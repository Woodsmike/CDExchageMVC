using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CDExchangeMVC.Startup))]
namespace CDExchangeMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
