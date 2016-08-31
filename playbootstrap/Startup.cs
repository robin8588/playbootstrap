using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(playbootstrap.Startup))]
namespace playbootstrap
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
