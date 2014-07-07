using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EFforDbFirst.Startup))]
namespace EFforDbFirst
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
