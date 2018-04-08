using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_02.BookLibrary.Startup))]
namespace _02.BookLibrary
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
