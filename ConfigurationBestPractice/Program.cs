// See https://aka.ms/new-console-template for more information

using Infrastructure;
using Infrastructure.IoC;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var configurationBuilder = new ConfigurationBuilder()
    .AddJsonFile("appSettings.json", true)
    .AddCommandLine(args)
    .AddEnvironmentVariables();

var configuration = configurationBuilder.Build();

var appBuilder = Host.CreateApplicationBuilder(args);

//First option
appBuilder.Services.ConfigureMyServices1(configuration);
//Second option
appBuilder.Services.ConfigureMyServices2(configuration["MyServiceLevelSetting"],
    configuration["ExternalUrl"],
    configuration["ConnectionString"],
    configuration["AnotherConfig"]);
//Third option
var myConfiguration = new MyConfiguration();
configuration.Bind(myConfiguration); //Match class properties to settings

appBuilder.Services.ConfigureMyServices3(myConfiguration);

//Fourth option
appBuilder.Services.AddOptions<MyConfiguration>()
    .Bind(configuration.GetSection(nameof(MyConfiguration)))
    .ValidateDataAnnotations()
    .ValidateOnStart();

appBuilder.Services.ConfigureMyServices4();

var app = appBuilder.Build();

var service = app.Services.GetRequiredService<IMyFirstService>();

await service.DoSomething("test");

await app.RunAsync();