using System;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using BlockRacer.Configuration;

namespace Main {
public class MainEntryPoint {
         public static void Main(string[] args) {
             var host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .CaptureStartupErrors(true)
                .Build();
            Console.WriteLine(host);
            host.Run();
        }
    }
}