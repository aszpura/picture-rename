using System;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using PictureRename.Models;

namespace PictureRename
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            var serviceProvider = serviceCollection.BuildServiceProvider();
            
            serviceProvider.GetService<Application>().Run();
        }

        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging(configure => configure.AddConsole().AddDebug().SetMinimumLevel(LogLevel.Warning));
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("app-settings.json", false)
                .Build();

            services.AddOptions();
            services.Configure<AppSettings>(configuration.GetSection("Configuration"));
            ConfigureConsole(configuration);

            services.AddTransient<Application>();
        }

        private static void ConfigureConsole(IConfigurationRoot configuration)
        {
            System.Console.Title = configuration.GetSection("Configuration:ConsoleTitle").Value;
        }
    }
}
