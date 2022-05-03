using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using TaskService.Plugin.EDBanks.Models;

namespace TaskService.Plugin.CBRTasks.Mappers
{
    public class EDMapper
    {
        public EDBanksModel Map(XmlNode node)
        {
            var model = new EDBanksModel();

            return model;
        }
    }
}
