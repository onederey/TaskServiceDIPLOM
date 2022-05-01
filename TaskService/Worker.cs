using System.Text.RegularExpressions;
using TaskService.CommonTypes.Classes;
using TaskService.CommonTypes.Interfaces;
using TaskService.CommonTypes.Sql;
using TaskService.Interfaces;

namespace TaskService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IPluginService _pluginService;
        private readonly IMailService _mailService;

        private ICollection<ITask> _plugins;

        public Worker(ILogger<Worker> logger, IPluginService pluginService, IMailService mailService)
        {
            _logger = logger;
            _pluginService = pluginService;
            _mailService = mailService;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            Thread pluginListener = new Thread(() => _pluginService.StartPluginListener(stoppingToken));
            pluginListener.Start();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    _plugins = GetMappedPlugins(_pluginService.GetPlugins());

                    if (_plugins == null || _plugins?.Count == 0)
                        _logger.LogWarning("No plugins availible");
                    else
                    {
                        Parallel.ForEach(_plugins, plugin =>
                        {
                            // [TODO]:
                            // Add auto-copy of plugin into build directory or project ! (only for my comfort)

                            if (IsNeedToWork(plugin))
                            {
                                _logger.LogInformation($"Scheduler: executing task - {plugin.Name}");

                                var result = plugin.Execute(stoppingToken, _logger);

                                HandleResult(result);
                            }
                            else
                            {
                                _logger.LogInformation($"Scheduler: task dont need to work - {plugin.Name}");
                            }
                        });
                    }
                }
                catch(Exception ex)
                {
                    _logger.LogCritical(ex.Message + "\nInnerException: " + ex.InnerException?.Message);
                }

                await Task.Delay(TaskServiceConst.DelayForTasks, stoppingToken);
            }
        }

        private bool IsNeedToWork(ITask task)
        {
            if (task == null || task.ServiceTask == null)
                return false;

            var dateStamp = DateTime.Now;
            var serviceTask = task.ServiceTask;

            if (serviceTask.ManualStart)
                return true;

            if (!serviceTask.IsEnabled)
                return false;

            if (serviceTask.LastWorkTime?.Date >= dateStamp.Date)
                return false;

            if (serviceTask.TaskStartTime.TimeOfDay >= dateStamp.TimeOfDay
                || serviceTask.TaskEndTime.TimeOfDay <= dateStamp.TimeOfDay)
                return false;

            if (!IsDependenciesResolved(serviceTask.Dependency, out var toResolve))
            {
                _logger.LogWarning($"Task {task.Name} - Needs to resolve dependencies: {toResolve}");
                return false;
            }

            return true;
        }

        private void HandleResult(TaskResult result)
        {
            // send mails, mark task last work date .... etc
        }

        private bool IsDependenciesResolved(string depends, out string resolveIt)
        {
            resolveIt = string.Empty;
            if (string.IsNullOrEmpty(depends))
                return true;

            foreach(var dep in depends.Split(';'))
            {
                var task = _plugins.FirstOrDefault(x => x.Name == dep);

                if (task == null) continue;

                if (task.ServiceTask?.LastWorkTime?.Date < DateTime.Now.Date)
                {
                    resolveIt += $"{task.Name};";
                }
            }

            if (string.IsNullOrEmpty(resolveIt))
                return true;

            return false;
        }

        private ICollection<ITask> GetMappedPlugins(ICollection<ITask> plugins)
        {
            var tasks = SqlDapper.ExecuteQuerySP<TaskDTO>("[dbo].[Service_GetAllTasks]");

            foreach(var plugin in plugins)
            {
                var task = tasks.FirstOrDefault(x => x.TaskName == plugin.Name);

                if (task != null)
                {
                    plugin.ServiceTask = task;
                }
            }

            return plugins;
        }
    }
}