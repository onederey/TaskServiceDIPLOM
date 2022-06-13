using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TaskService.API.DataManagers;
using TaskService.Interface.Areas.Identity.Data;
using TaskService.Interface.Models;

namespace TaskService.Interface.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _db;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _db = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var taskDTO = new ServiceTaskViewModel();
            taskDTO.GetTaskDTOs = _db.ServiceTasks.ToList();
            return View(taskDTO);
        }

        public IActionResult Viewer()
        {
            return View();
        }

        public IActionResult ReportDesigner()
        {
            return View();
        }

        public IActionResult Modified()
        {
            var taskDTO = new ServiceTaskViewModel();
            taskDTO.GetTaskDTOs = _db.ServiceTasks.ToList();
            return View(taskDTO);
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