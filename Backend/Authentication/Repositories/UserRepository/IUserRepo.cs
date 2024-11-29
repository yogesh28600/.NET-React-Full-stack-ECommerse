using Authentication.Models;

namespace Authentication.Repositories.UserRepository;
public interface IUserRepo{
    public Task<List<User>> GetUsers();
    public Task<User> GetUser(Guid id);
    public Task<User> CreateUser(User user);
    public Task<User> UpdateUser(User user);
    public Task<User> FindUser(string email);
    public Task<User> DeleteUser(Guid id);
}