using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GUITrainingBank.Startup))]
namespace GUITrainingBank
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
