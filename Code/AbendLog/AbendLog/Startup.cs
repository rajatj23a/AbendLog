using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(AbendLog.Startup))]
namespace AbendLog
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
