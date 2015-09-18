using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CRMebyas.Startup))]
namespace CRMebyas
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
