using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace Infrastructure.IoC;

public static class ConfigurationExtensions
{
    public static IServiceCollection ConfigureMyServices1(this IServiceCollection services, IConfiguration configuration)
    {
        var readMySettings = configuration["MyServiceLevelSetting"];
        services.AddScoped<IMyFirstService, MyFirstService>();
        return services;
    }

    public static IServiceCollection ConfigureMyServices3(this IServiceCollection services, MyConfiguration myConfiguration)
    {
        var readMySettings = myConfiguration.MyServiceLevelSetting;
        services.AddScoped<IMyFirstService, MyThirdService>();
        return services;
    }

    public static IServiceCollection ConfigureMyServices4(this IServiceCollection services)
    {
        services.AddScoped<IMyFirstService, MyFourthService>();
        return services;
    }
    public static IServiceCollection ConfigureMyServices2(this IServiceCollection services, string myServiceLevelSetting, string externalUrl, string connectionString, string anotherConfig)
    {
        var readMySettings = myServiceLevelSetting;
        services.AddScoped<IMyFirstService>(c => new MySecondService(externalUrl, connectionString, anotherConfig));
        return services;
    }
}