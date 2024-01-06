using WebApp.Models.Db.Entities;
using WebApp.Models.Db.Repositories;
namespace WebApp.Middlewares
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IRequestRepository _logRepo;

        /// <summary>
        ///  Middleware-компонент должен иметь конструктор, принимающий RequestDelegate
        /// </summary>
        public LoggingMiddleware(RequestDelegate next, IRequestRepository logRepo)
        {
            _next = next;
            _logRepo = logRepo;
        }

        /// <summary>
        ///  Необходимо реализовать метод Invoke или InvokeAsync
        /// </summary>
        public async Task InvokeAsync(HttpContext context)
        {
            LogToConsole(context);
            await LogToDB(context);
            await _next.Invoke(context);
        }

        private async Task LogToDB(HttpContext context)
        {
            Request request = new()
            {
                Id = Guid.NewGuid(),
                Date = DateTime.Now,
                Url = $"http://{context.Request.Host.Value + context.Request.Path}"
            };

            await _logRepo.AddRequest(request);
        }

        private static void LogToConsole(HttpContext context) => Console.WriteLine($"[{DateTime.Now}]: New request to http://{context.Request.Host.Value + context.Request.Path}");
    }
}
