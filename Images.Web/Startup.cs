using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Images.Web.Startup))]
namespace Images.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
