using System;
using System.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(SignalRTeste.Startup))]

namespace SignalRTeste
{
    public class Startup
    {
        private static string Get()
        {
            return ConfigurationManager.AppSettings["redis"] ?? "localhost2";
        }
        private static string _redis => Get();
        public void Configuration(IAppBuilder app)
        {
            GlobalHost.DependencyResolver.UseRedis(_redis, 6379, "", "ChatRedis");
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            app.MapSignalR();
            GlobalHost.HubPipeline.RequireAuthentication();
        }
    }
}
