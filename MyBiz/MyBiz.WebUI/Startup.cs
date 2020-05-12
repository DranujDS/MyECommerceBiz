using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyBiz.WebUI.Startup))]
namespace MyBiz.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
