using Owin;
using Microsoft.Owin;
[assembly: OwinStartup(typeof(Task_1.Startup))]
namespace Task_1
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            // Any connection or hub wire up and configuration should go here
            app.MapSignalR();
        }
    }
}