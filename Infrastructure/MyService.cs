using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace Infrastructure;

public interface IMyFirstService
{
    Task DoSomething(string action);
}

public class MyFirstService : IMyFirstService
{
    string _externalUrl;
    string _connectionString;
    string _anotherConfig;
    public MyFirstService(IConfiguration configuration)
    {
        _externalUrl = configuration["ExternalUrl"] ?? throw new InvalidOperationException();
        _connectionString = configuration["ConnectionString"] ?? throw new InvalidOperationException();
        _anotherConfig = configuration["AnotherConfig"] ?? throw new InvalidOperationException();
    }

    public Task DoSomething(string action)
    {
        //Do something with the configured url;
        Console.WriteLine($"Performed {action} to Url {_externalUrl}");
        return Task.CompletedTask;
    }
}

public class MySecondService : IMyFirstService
{
    string _externalUrl;
    string _connectionString;
    string _anotherConfig;
    public MySecondService( string externalUrl, string connectionString, string anotherConfig)
    {
        _externalUrl = externalUrl;
        _connectionString = connectionString;
        _anotherConfig = anotherConfig;
    }

    public Task DoSomething(string action)
    {
        //Do something with the configured url;
        Console.WriteLine($"Performed {action} to Url {_externalUrl}");
        return Task.CompletedTask;
    }
}
public class MyThirdService : IMyFirstService
{
    string _externalUrl;
    string _connectionString;
    string _anotherConfig;
    public MyThirdService(MyConfiguration configuration)
    {
        _externalUrl = configuration.ExternalUrl;
        _connectionString = configuration.ConnectionString;
        _anotherConfig = configuration.AnotherConfig;
    }

    public Task DoSomething(string action)
    {
        //Do something with the configured url;
        Console.WriteLine($"Performed {action} to Url {_externalUrl}");
        return Task.CompletedTask;
    }
}

public class MyFourthService : IMyFirstService
{
    string _externalUrl;
    string _connectionString;
    string _anotherConfig;
    public MyFourthService(IOptions<MyConfiguration> configuration)
    {
        _externalUrl = configuration.Value.ExternalUrl;
        _connectionString = configuration.Value.ConnectionString;
        _anotherConfig = configuration.Value.AnotherConfig;
    }

    public Task DoSomething(string action)
    {
        //Do something with the configured url;
        Console.WriteLine($"Performed {action} to Url {_externalUrl}");
        return Task.CompletedTask;
    }
}