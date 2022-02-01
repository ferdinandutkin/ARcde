using System.Reflection;
using Auto;
using Auto.Interfaces;
using Auto.IO;
using Auto.Product;
using Data.Repository;
using IO.RequestProcessor;
using MediatR;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Routing;
using Shared;
using Web;
using Web.IO;
using Web.Mediator.Handlers;
using Web.Mediator.Requests;


var builder = WebApplication.CreateBuilder(args);


builder.Logging.ClearProviders();
builder.Logging.AddConsole();

builder.Services.AddSingleton<ILogger>(provider => 
    provider.GetRequiredService<ILogger<Unit>>());

builder.Services.AddSingleton(builder.Configuration.GetStorageConfigurations());

builder.Services.AddSingleton<IFactory<string, IRepository<CarProduct>>, RepositoryFactory>();


builder.Services.AddSingleton<CarProductReceiver>();
builder.Services.AddSingleton<IIOProvider, WebIOProvider>();
builder.Services.AddSingleton<HeadOffice>();
builder.Services.AddSingleton<IUserRequestProcessor, HeadOfficeUserRequestProcessor>();
builder.Services.AddTransient<IRequestHandler<BuyRequest, Unit>, UserRequestHandler<BuyRequest>>();
builder.Services.AddTransient<IRequestHandler<SellRequest, Unit>, UserRequestHandler<SellRequest>>();
builder.Services.AddTransient<IRequestHandler<AddRequest, Unit>, UserRequestHandler<AddRequest>>();


 
builder.Services.AddSingleton<IUrlHelperFactory, UrlHelperFactory>();


builder.Services.AddControllersWithViews();


builder.Services.AddMediatR(Assembly.GetExecutingAssembly());

 

var app = builder.Build();

app.MapControllers();

app.UseStaticFiles();


app.Run();
