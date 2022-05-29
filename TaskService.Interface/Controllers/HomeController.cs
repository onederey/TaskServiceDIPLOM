using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaskService.API.DataManagers;
using TaskService.CommonTypes.Classes;
using TaskService.Interface.Areas.Identity.Data;
using TaskService.Interface.Models;

namespace TaskService.Interface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var tt = new TaskDataManager();
            var taskDTO = new TaskDTOViewModel();
            taskDTO.GetTaskDTOs = tt.GetTasks();
            return View(taskDTO);
        }

        public IActionResult Reports()
        {
            return View();
        }

        public IActionResult Plugins()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}