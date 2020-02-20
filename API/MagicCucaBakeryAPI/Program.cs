using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using ArgsSplitter.business;
using ArgsSplitter.models;
using System.Collections.Generic;

namespace MagicCucaBakery.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args)
        {
            ASplitter menu = LoadMenu();
            Dictionary<string, string> argsList = new Dictionary<string, string>();
            if (args.Length > 1)
            {
                argsList =  menu.ProcessArgs(args);
            }          

            return Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    List<string> urls = new List<string>() { $"http://0.0.0.0:{argsList.GetValueOrDefault("PORT", "5000")}", 
                                                             $"https://0.0.0.0:{argsList.GetValueOrDefault("PORT_HTTPS", "5001")}" };
                    webBuilder.UseStartup<Startup>().UseUrls(urls.ToArray());
                });
        }


        private static ASplitter LoadMenu()
        {
            ASplitterSettings settings = new ASplitterSettings(new List<Arg>()
            {
                new Arg("Port http",
                    new List<string>() { "-http" },
                    new List<Param>() { new Param("port", "PORT", true, "5000", "port", false) },
                    new List<Arg>(),
                    ""),
                new Arg("Port https",
                    new List<string>() { "-https" },
                    new List<Param>() { new Param("port https", "PORT_HTTPS", true, "5001", "port https", false) },
                    new List<Arg>(),
                    "")
            });
            return new ASplitter(settings);
        }
    }
}
