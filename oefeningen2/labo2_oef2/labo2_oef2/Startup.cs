using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(labo2_oef2.Startup))]
namespace labo2_oef2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
