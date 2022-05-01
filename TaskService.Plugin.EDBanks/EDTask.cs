﻿using Microsoft.Extensions.Logging;
using TaskService.CommonTypes.Classes;
using TaskService.CommonTypes.Interfaces;

namespace TaskService.Plugin.EDBanks
{
    public class EDTask : ITask
    {
        public string Name => "EDBanks";

        public TaskDTO ServiceTask { get; set; }

        public TaskResult Execute(CancellationToken token, ILogger logger)
        {
            if (token.IsCancellationRequested)
                return new TaskResult(true);

            logger.LogInformation($"Start working - {Name}");
            var taskResult = new TaskResult();

            try
            {
                
            }
            catch (Exception ex)
            {
                logger.LogError(ex, $"Error while processing - {Name}");
                taskResult.AddWarning($"Error while processing - {Name}", true);
            }

            logger.LogInformation($"End working - {Name}");
            return taskResult;
        }
    }
}