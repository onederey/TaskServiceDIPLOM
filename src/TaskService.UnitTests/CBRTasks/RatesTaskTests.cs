using Microsoft.Extensions.Logging;
using Moq;
using NUnit.Framework;
using System.Threading;
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
        }

        [Test]
        public void Execute_ExpectedWork_NoSpecialParams()
        {
            _task.Execute(_token, _loggerMock.Object);
        }
    }
}
