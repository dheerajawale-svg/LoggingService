using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Natus.Logging.Client;

namespace LoggingTester
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using IHost host = Host.CreateDefaultBuilder(args)
                .ConfigureServices((_, services) =>
                    {
                        services.AddHttpClient();
                        services.AddSingleton<INatusLogger, NatusLogger>();
                    }
                ).Build();

            var _logger = host.Services.GetRequiredService<INatusLogger>();

            _logger.Debug("Debug Hello From Sukhas");
            _logger.Info("Info Hello From Sukhas");
            _logger.Warning("Warning Hello From Sukhas");
            _logger.Error("Error Hello From Sukhas");
            _logger.Fatal("Fatal Hello From Sukhas");
            _logger.UserAction("ABC", "Prod1", "BPPV", "1.0", "User clicked");
            _logger.AuditTrail("ABC", "Prod1", "BPPV", "1.0", "Sukhas", "User clicked");

            Console.ReadLine();
        }
    }
}