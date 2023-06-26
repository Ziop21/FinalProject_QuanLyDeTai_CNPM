using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(QuanLyDeTai.Startup))]
namespace QuanLyDeTai
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
