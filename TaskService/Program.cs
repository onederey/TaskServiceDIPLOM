using NLog.Web;
using TaskService;
using TaskService.CommonTypes.Interfaces;
using TaskService.CommonTypes.Sql;

var logger = NLogBuilder.ConfigureNLog("nlog.config").GetCurrentClassLogger();

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile(File.Exists("appsettings.Development.json") ? "appsettings.Development.json" : "appsettings.json")
            .Build();

        SqlDapper.InitDapper(
            config.GetSection("Settings:ConnectionString").Value,
            config.GetSection("Settings:CommandTimeout").Value);

        services
            .AddSingleton<IPluginLoader, PluginLoader>()
            .AddHostedService<Worker>();
    })
    .ConfigureLogging(logging =>
    {
        logging.ClearProviders();
        logging.SetMinimumLevel(LogLevel.Trace);
    })
    .UseNLog()
    .UseWindowsService(x => x.ServiceName = "TaskService host")
    .Build();

await host.RunAsync();
