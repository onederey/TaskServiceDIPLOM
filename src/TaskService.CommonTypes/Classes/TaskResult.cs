using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.CommonTypes.Classes
{
    /// <summary>
    /// All plugins return TaskResult
    /// </summary>
    public class TaskResult
    {
        public ICollection<TaskWarning> taskWarnings { get; set; } = new List<TaskWarning>();

        public void AddWarning(string message, bool IsCritical, int? recordId = null)
        {
            taskWarnings.Add(new TaskWarning
            {
                IsCritical = IsCritical,
                Message = recordId.HasValue ? string.Join('.', recordId, message) : message,
            });
        }

        public bool IsError => taskWarnings.Any(x => x.IsCritical);
    }
}
