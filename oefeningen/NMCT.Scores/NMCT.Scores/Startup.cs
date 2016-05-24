using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(NMCT.Scores.Startup))]
namespace NMCT.Scores
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
