using System.Text.RegularExpressions;
using TaskService.CommonTypes.Classes;
using TaskService.Interfaces;

namespace TaskService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPluginService _pluginService;

        public Worker(ILogger<Worker> logger, IPluginService pluginService)
        {
            _logger = logger;
            _pluginService = pluginService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Thread pluginListener = new Thread(() => _pluginService.StartPluginListener(stoppingToken));
            pluginListener.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                var plugins = _pluginService.GetPlugins();

                if (plugins.Count == 0)
                    _logger.LogWarning("No plugins availible");

                foreach (var plugin in plugins)
                {
                    // [TODO]:
                    // Add link to scheduler from db
                    // Check execution rules
                    // Add auto-copy of plugin into build directory or project ! (only for my comfort)

                    plugin.Execute(stoppingToken, _logger);
                }

                await Task.Delay(TaskServiceConst.DelayForTasks, stoppingToken);
            }
        }
    }
}