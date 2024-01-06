using WebApp.Models.Db.Entities;

namespace WebApp.Models.Db.Repositories
{
    public interface IBlogRepository
    {
        Task AddUser(User user);
        Task<User[]> GetUsers();
    }
}
