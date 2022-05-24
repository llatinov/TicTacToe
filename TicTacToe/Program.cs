using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace TicTacToe;

public static class Program
{
    public static void Main(string[] args)
    {
        CreateWebHostBuilder(args).Build().Run();
    }

    public static IWebHostBuilder CreateWebHostBuilder(string[] args)
    {
        var port = Environment.GetEnvironmentVariable("SERVICE_PORT");
        return WebHost.CreateDefaultBuilder(args)
            .UseStartup<Startup>()
            .UseUrls($"http://*:{port}");
    }
}
