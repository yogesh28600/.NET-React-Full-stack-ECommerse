using Authentication.Context;
using Authentication.Models;
using Microsoft.EntityFrameworkCore;

namespace Authentication.Repositories.UserRepository;
public class UserRepo : IUserRepo
{
    private readonly UserDbContext _context;
    public UserRepo(UserDbContext context)
    {
        _context = context;
    }
    public async Task<User> CreateUser(User user)
    {
        try
        {
            var added_user = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
            return added_user.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserRepo/CreateUser: {ex.Message}");
            return null;
        }
    }
    public async Task<User> DeleteUser(Guid id)
    {
        try
        {
            var user = await GetUser(id);
            if (user != null){
               var deleted_user = _context.Users.Remove(user);
               await _context.SaveChangesAsync();
               return deleted_user.Entity;
            }
            return null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserRepo/DeleteUser: {ex.Message}");
            return null;
        }

    }
    public async Task<User> GetUser(Guid id)
    {
        try
        {
            return await _context.Users.FindAsync(id);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserRepo/GetUser: {ex.Message}");
            return null;
        }
    }
    public async Task<List<User>> GetUsers()
    {
        try
        {
           return await _context.Users.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserRepo/GetUsers: {ex.Message}");
            return null;
        }
    }
    public async Task<User> FindUser(string email)
    {
        try
        {
            var user = await _context.Users.FirstAsync(u => u.email == email);
            return user != null ? user : null;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserRepo/FindUser: {ex.Message}");
            return null;
        }
    }
    public async Task<User> UpdateUser(User user)
    {
        try
        {
            var existingEntity = _context.Users.Find(user.Id);
            if (existingEntity != null)
            {
                _context.Entry(existingEntity).State = EntityState.Detached;
            }
            var updated_user = _context.Users.Update(user);
            Console.WriteLine(updated_user.Entity.middleName);
            await _context.SaveChangesAsync();
            return updated_user.Entity;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserRepo/UpdateUser: {ex.Message}");
            return null;
        }
    }
}