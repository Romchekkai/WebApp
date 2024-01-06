using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebApp.Models;
using WebApp.Models.Db.Repositories;
using WebApp.Models.Db.Entities;

namespace WebApp.Controllers
{
    public class LogsController : Controller
    {
        private readonly IRequestRepository _requestRepository;

        public LogsController(IRequestRepository requestRepository)
        {
            _requestRepository = requestRepository;
        }

        public async Task<IActionResult> Index()
        {

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logs()
        {
            var request = await _requestRepository.GetRequest();
            return View(request);
        }

        [HttpPost]
        public async Task<IActionResult> Logs(Request request)
        {
            await _requestRepository.AddRequest(request);
            return View(request);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
