using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskService.CommonTypes.Interfaces;

namespace TaskService.CommonTypes.Classes
{
    public class MailService : IMailService
    {
        public void InitMailService()
        {

        }

        public void SendMail(string taskName, int taskId, ICollection<TaskWarning> taskWarnings)
        {

        }

        private string GetMessage()
        {
            throw new NotImplementedException();
        }
    }
}
