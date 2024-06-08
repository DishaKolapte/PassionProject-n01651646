using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PassionProject_n01651646.Startup))]
namespace PassionProject_n01651646
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
