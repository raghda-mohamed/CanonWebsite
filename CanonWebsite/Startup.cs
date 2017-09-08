using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CanonWebsite.Startup))]
namespace CanonWebsite
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
