using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System;
using System.Text;
using System.Threading;
using TaskService.CommonTypes.Classes;
using TaskService.CommonTypes.Interfaces;
using TaskService.CommonTypes.Sql;
using TaskService.Plugin.CBRTasks;

namespace TaskService.UnitTests.CBRTasks
{
    [TestFixture]
    public class RatesTaskTests
    {
        private Mock<ILogger> _loggerMock;
        private CancellationToken _token;
        private ITask _task;

        [SetUp]
        public void SetUp()
        {
            SqlDapper.InitDapper("Data Source=.;Initial Catalog=dbBankGM;Integrated Security=true", "200");

            _loggerMock = new Mock<ILogger>();
            _token = new CancellationToken();
            _task = new RatesTask();

            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        [Test]
        public void Execute_ExpectedWork_NoSpecialParams()
        {
            _task.Execute(_token, _loggerMock.Object);
        }

        [Test]
        public void DebugTest()
        {
            _task = new EDTask(); //https://www.cbr.ru/s/newbik
            _task.ServiceTask = new TaskDTO
            {
                Url = "https://www.cbr.ru/s/newbik",
                FilePath = AppDomain.CurrentDomain.BaseDirectory,
                FileMask = "*_ED807_full.xml"
            };

            // add rates hist task to copy rates into rates hist table
            // add api for interface in data manager

            _task.Execute(_token, _loggerMock.Object);
        }
    }
}
