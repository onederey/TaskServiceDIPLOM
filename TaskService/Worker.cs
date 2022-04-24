using System.Text.RegularExpressions;
using TaskService.CommonTypes.Interfaces;

namespace TaskService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPluginLoader _pluginLoader;

        private CancellationTokenSource _cts;
        private Regex _patternForPlugins = new Regex("^TaskService[.]Plugin[.][a-zA-Z.]+[.]dll$");

        public Worker(ILogger<Worker> logger, IPluginLoader pluginLoader)
        {
            _logger = logger;
            _pluginLoader = pluginLoader;
            _cts = new CancellationTokenSource();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var plugins = _pluginLoader.LoadPlugins(GetAssemblyPaths());

            while (!stoppingToken.IsCancellationRequested)
            {
                foreach(var plugin in plugins)
                {
                    // [TODO]:
                    // Add link to scheduler from db
                    // Check execution rules
                    // Add listener for dynamic plugin loading
                    // Add auto-copy of plugin into build directory or project

                    plugin.Execute(_cts.Token, _logger);
                }

                await Task.Delay(1000, stoppingToken);
            }
        }

        private string[] GetAssemblyPaths()
        {
            return Directory
                .GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.*", SearchOption.AllDirectories)
                .Where(x => _patternForPlugins.IsMatch(Path.GetFileName(x)))
                .ToArray();
        }
    }
}