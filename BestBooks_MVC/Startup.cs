using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BestBooks_MVC.Startup))]
namespace BestBooks_MVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
