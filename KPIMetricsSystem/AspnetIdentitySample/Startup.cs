using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(KpiMetricsSystem.Startup))]
namespace KpiMetricsSystem
{
    public partial class Startup 
    {
        public void Configuration(IAppBuilder app) 
        {
            ConfigureAuth(app);
        }
    }
}
