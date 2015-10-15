using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(SchoolWeb.Startup))]
namespace SchoolWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
