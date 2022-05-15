using Microsoft.Extensions.Logging;
using TaskService.CommonTypes.Classes;
using TaskService.CommonTypes.Interfaces;

namespace TaskService.Plugin.Clients
{
    public class ClientsTask : ITask
    {
        public string Name => throw new NotImplementedException();

        public TaskDTO ServiceTask { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public TaskResult Execute(CancellationToken token, ILogger logger)
        {
            throw new NotImplementedException();
        }
    }
}