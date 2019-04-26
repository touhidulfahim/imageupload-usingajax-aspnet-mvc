using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ImageUploadApp.Startup))]
namespace ImageUploadApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
