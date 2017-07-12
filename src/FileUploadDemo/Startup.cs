using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FileUploadDemo.Startup))]
namespace FileUploadDemo
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
