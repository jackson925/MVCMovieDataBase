using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MVCMovieDB.Startup))]
namespace MVCMovieDB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
