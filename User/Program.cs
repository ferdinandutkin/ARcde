using Auto;
using Microsoft.Extensions.Configuration;
using Shared.IO;
using Shared.Logging;
using User.RequestProcessor;

namespace User;

public class Program
{
    static void Main()
    {
        var configurations = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false)
                .Build()
                .GetLoggerConfigurations();



        var logger = new LoggerFactory()
            .FromConfigurations(configurations);


        new InputProcessor(
            new RequestParser(),
            new UserRequestProcessor(
                new HeadOffice(logger)), IOProvider.Instance).Start();

    }
}