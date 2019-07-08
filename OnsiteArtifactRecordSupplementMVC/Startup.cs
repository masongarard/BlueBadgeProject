using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(OnsiteArtifactRecordSupplementMVC.Startup))]
namespace OnsiteArtifactRecordSupplementMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
