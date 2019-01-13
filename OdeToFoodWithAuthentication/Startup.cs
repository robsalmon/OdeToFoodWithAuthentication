using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OdeToFoodWithAuthentication.Startup))]
namespace OdeToFoodWithAuthentication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
