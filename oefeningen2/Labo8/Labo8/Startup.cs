using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Labo8.Startup))]
namespace Labo8
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
