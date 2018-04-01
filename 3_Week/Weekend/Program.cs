using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace weekend_session
{
    public class Program
    {
        public static void Main(string[] args)
        {

            DateTime now = DateTime.Now;
            List<Friend> friends = Friend.MakeFriends();

            string friendsAsJson = JsonConvert.SerializeObject(friends);
            List<Friend> friendsAgain = JsonConvert.DeserializeObject<List<Friend>>(friendsAsJson);

            


            System.Console.WriteLine(now.ToAwesomeFormat("g"));
            
         
            // BuildWebHost(args).Run();
        }
       

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
