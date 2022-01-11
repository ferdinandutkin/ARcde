using System.Reflection;
using Auto;
using Auto.Interfaces;
using Auto.IO;
using Auto.Product;
using Data.Repository;
using IO.RequestProcessor;
using MediatR;
using Shared;
using Web;
using Web.IO;
using Web.Mediator.Handlers;
using Web.Mediator.Requests;
using LoggerFactory = Shared.Logging.LoggerFactory;

var builder = WebApplication.CreateBuilder(args);



builder.Services.Configure<List<StorageConfiguration>>(builder.Configuration.GetSection("Storage"));


builder.Services.AddSingleton(builder.Configuration.GetStorageConfigurations());

builder.Services.AddSingleton<IFactory<string, IRepository<CarProduct>>, RepositoryFactory>();


var loggerConfigurations = builder.Configuration.GetLoggerConfigurations();

var logger = new LoggerFactory()
    .FromConfigurations(loggerConfigurations);

builder.Services.AddSingleton(logger);
builder.Services.AddSingleton<CarProductReceiver>();
builder.Services.AddSingleton<IIOProvider, WebIOProvider>();
builder.Services.AddSingleton<HeadOffice>();
builder.Services.AddSingleton<IUserRequestProcessor, HeadOfficeUserRequestProcessor>();
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IRequestHandler<BuyRequest, Unit>, UserRequestHandler<BuyRequest>>();
builder.Services.AddTransient<IRequestHandler<SellRequest, Unit>, UserRequestHandler<SellRequest>>();



builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

builder.Host.ConfigureLogging(logging =>
{
    logging.ClearProviders();
    logging.AddConsole();
});

var app = builder.Build();

app.MapControllers();

app.UseStaticFiles();


app.Run();
