using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.CommonTypes.Interfaces
{
    public interface IPluginLoader
    {
        ICollection<ITask> LoadPlugins(string[] pluginPaths);
    }
}
