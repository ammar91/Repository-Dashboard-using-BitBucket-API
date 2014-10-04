using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BitBucketWeb.Startup))]
namespace BitBucketWeb
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
