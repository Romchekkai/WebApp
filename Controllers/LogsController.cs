using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Models.Db.Repositories;
using WebApp.Models.Db.Entities;

namespace WebApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _repo;

        public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }


        public async Task<IActionResult> Index()
        {
            var logs = await _repo.GetRequest();
            return View(logs);
        }

    }
}
/*public LogsController(IRequestRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Logs() 
        { return View(); }
        public async Task<IActionResult> Logs()
        {
            var logs = await _repo.GetRequest();
            return View(logs);
        }

 
 
 
 var request = await _repo.GetRequest();
            return View(request);*/