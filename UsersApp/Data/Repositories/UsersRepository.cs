using UsersApp.Data.Entities;

namespace UsersApp.Data.Repositories
{
    public interface IUsersRepository
    {
        User? GetByName(string username);
    }
    public class UsersRepository : IUsersRepository
    {
        private readonly MyDbContext _dbContext;
        public UsersRepository(MyDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public User? GetByName(string username)
        {
            return _dbContext.Users.FirstOrDefault(u => u.UserName==username);
        }
    }
}
