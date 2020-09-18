using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PictureRename.Models;

namespace PictureRename
{
    public class Application
    {
        private readonly ILogger<Application> _logger;
        private readonly AppSettings _config;

        public Application(IOptions<AppSettings> config, ILogger<Application> logger)
        {
            _logger = logger;
            _config = config.Value;
        }

        public void Run()
        {
            _logger.LogInformation($"This is a console application for {_config.ConsoleTitle}");
            
            System.Console.ReadKey();
        }
    }
}