using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ClashOfClans.Startup))]
namespace ClashOfClans
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
