using Auto;
using Console.IO;
using Data.Repository;
using Microsoft.Extensions.Configuration;
using Shared;
using Shared.Logging;

namespace Console;

public class Program
{
    static void Main()
    {
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false)
            .Build();
        
        var loggerConfigurations = configuration.GetLoggerConfigurations();
        var storageConfigurations = configuration.GetStorageConfigurations();
        
        var logger = new LoggerFactory()
            .FromConfigurations(loggerConfigurations);
        var ioProvider = new ConsoleIOProvider();

        new InputProcessor(
            new RequestParser(),
            new ConsoleRequestProcessor(
                new HeadOffice(new RepositoryFactory(storageConfigurations), ioProvider, logger)), ioProvider).Start();

    }
}