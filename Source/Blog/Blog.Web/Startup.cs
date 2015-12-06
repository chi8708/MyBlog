using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Blog.Web.Startup))]
namespace Blog.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
