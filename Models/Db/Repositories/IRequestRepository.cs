using Microsoft.EntityFrameworkCore;
using WebApp.Models.Db.Entities;

namespace WebApp.Models.Db.Repositories
{
    public interface IRequestRepository
    {
        Task AddRequest(Request request);
        Task<Request[]> GetRequest();
    }
}
