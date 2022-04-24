using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService.CommonTypes.Classes;

namespace TaskService.CommonTypes.Interfaces
{
    /// <summary>
    /// Interface for plugin task
    /// </summary>
    public interface ITask
    {
        /// <summary>
        /// Obsolete ?...
        /// </summary>
        string Id { get; }

        /// <summary>
        /// Obsolete ?...
        /// </summary>
        string Name { get; }

        /// <summary>
        /// DTO for sheduler
        /// </summary>
        TaskDTO ServiceTask { get; set; }

        /// <summary>
        /// Main method for plugins
        /// </summary>
        /// <returns>
        /// Returns TaskResult with errors/warnings and results of task execution
        /// </returns>
        TaskResult Execute(CancellationToken token);

        /// <summary>
        /// Obsolete ?..
        /// </summary>
        TaskResult Execute(CancellationToken token, params string[] parameters);
    }
}
