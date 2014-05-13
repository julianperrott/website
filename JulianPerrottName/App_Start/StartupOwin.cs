using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using JulianPerrottName.Areas.Feedback.Models;
using Owin;

[assembly: OwinStartup(typeof(JulianPerrottName.App_Start.StartupOwin))]

namespace JulianPerrottName.App_Start
{
    public class StartupOwin
    {
        public void Configuration(IAppBuilder app)
        {
            app.MapSignalR<TaskConnection>("/echo");
        }
    }
}
