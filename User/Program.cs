using Auto;
using Data.Repository;
using Microsoft.Extensions.Configuration;
using Shared.IO;
using Shared.Logging;
using User.RequestProcessor;

namespace User;

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


        new InputProcessor(
            new RequestParser(),
            new UserRequestProcessor(
                new HeadOffice(new RepositoryFactory(storageConfigurations))), IOProvider.Instance).Start();

    }
}