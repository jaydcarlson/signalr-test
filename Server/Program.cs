using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Treehopper;
using Treehopper.Libraries.Displays;
using Microsoft.AspNet.SignalR;
using Microsoft.Owin.Cors;
using Owin;
using Microsoft.Owin.Hosting;
using System.Threading;

namespace Test2
{
    class Program
    {
        static void Main(string[] args)
        {
            string url = "http://localhost:8080";
            using (WebApp.Start(url))
            {
                Console.WriteLine("Server running on {0}", url);
                //Console.ReadLine();
                while(true)
                {
                    var hubContext = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                    hubContext.Clients.All.SayHello("The current server time is: " + DateTime.Now.ToLongTimeString());
                    Thread.Sleep(1000);
                }
            }
        }

    }
    class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            app.MapSignalR();
        }
    }
    public class MyHub : Hub
    {
        public void Send()
        {
            Debug.WriteLine("Send() method called on server");
            Clients.All.SayHello("Hey, world!");
        }
    }
}
