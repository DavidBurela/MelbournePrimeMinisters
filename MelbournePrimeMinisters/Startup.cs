using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MelbournePrimeMinisters.Startup))]
namespace MelbournePrimeMinisters
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
