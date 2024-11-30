using Authentication.DTO;
using Authentication.Models;
using Authentication.Services;
using Authentication.Repositories.UserRepository;
using Microsoft.AspNetCore.Mvc;

namespace Authentication.Controllers;

[ApiController]
[Route("yk-techtown/api")]
public class UserController : ControllerBase
{
    private readonly IUserRepo _userRepo;
    public UserController(IUserRepo userRepo)
    {
        _userRepo = userRepo;
    }
    [HttpGet("users")]
    public async Task<IActionResult> GetUsers(){
        try
        {
            var users = await _userRepo.GetUsers();
            if (users == null) return BadRequest(new {error="Something went wrong while fetching data..."});
            return Ok(users);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserController/GetUsers: {ex.Message}");
            return BadRequest(new {error="Something went wrong while fetching data..."});
        }
    }
    [HttpPost("users/register")]
    public async Task<IActionResult> CreateUser([FromBody]CreateUserDTO userDTO)
    {
        try
        {
            var existing_user = await _userRepo.FindUser(userDTO.email);
            if (existing_user != null) return BadRequest(new {error="Email already exists..."});
            string password = userDTO.password;
            var passwordService = new PasswordService();
            var hashedPassword = passwordService.HashPassword(password);
            var user = new User(){
                firstName = userDTO.firstName,
                middleName = userDTO.middleName != null ? userDTO.middleName : "",
                lastName = userDTO.lastName,
                email = userDTO.email,
                passwordHash = hashedPassword,
            };
            var created_user = await _userRepo.CreateUser(user);
            if (user == null) return BadRequest(new {error="Something went wrong while creating user..."});
            return CreatedAtAction(nameof(GetUsers), created_user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserController/CreateUser: {ex.Message}");
            return BadRequest(new {error="Something went wrong while creating user..."});
        }
    }
    [HttpPost("users/login")]
    public async Task<IActionResult> LoginUser([FromBody]LoginUserDTO loginDTO)
    {
        try
        {
            var fetched_user = await _userRepo.FindUser(loginDTO.email);
            if (fetched_user == null) return NotFound(new {error="User not found"});
            var passwordService = new PasswordService();
            bool isValidPassword = passwordService.VerifyPassword(fetched_user.passwordHash, loginDTO.password);
            if (!isValidPassword) return BadRequest(new {error="Invalid password"});
            var generateToken = new GenerateToken();
            var token = generateToken.generate(fetched_user.email);
            return Ok(new GetUserWithTokenDTO(){
                id = fetched_user.Id,
                firstName = fetched_user.firstName,
                middleName = fetched_user.middleName,
                lastName = fetched_user.lastName,
                email = fetched_user.email,
                token = token
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserController/LoginUser: {ex.Message}");
            return BadRequest(new {error="Something went wrong while logging in user..."});
        }
    }
    [HttpGet("users/{id}")]
    public async Task<IActionResult> GetUser(Guid id)
    {
        try
        {
            var fetched_user = await _userRepo.GetUser(id);
            if (fetched_user == null) return NotFound(new {error="User not found"});
            return Ok(new GetUserDTO(){
                id = fetched_user.Id,
                firstName = fetched_user.firstName,
                middleName = fetched_user.middleName,
                lastName = fetched_user.lastName,
                email = fetched_user.email
            });
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserController/GetUser: {ex.Message}");
            return BadRequest(new {error="Something went wrong while fetching user..."});
        }
    }
    [HttpPatch("users/{id}")]
    public async Task<IActionResult> UpdateUser([FromRoute]Guid id,[FromBody]UpdateUserDTO updateUserDTO)
    {
        try
        {
            var fetched_user = await _userRepo.GetUser(id);
            if (fetched_user == null) return NotFound(new {error="User not found"});
            string passwordHash=null;
            if (updateUserDTO.password != null) {
                var passwordService = new PasswordService();
                passwordHash=passwordService.HashPassword(updateUserDTO.password);
            }
            var user = new User()
            {
                Id = id,
                firstName = updateUserDTO.firstName != null ? updateUserDTO.firstName : fetched_user.firstName,
                middleName = updateUserDTO.middleName != null ? updateUserDTO.middleName : fetched_user.middleName,
                lastName = updateUserDTO.lastName != null ? updateUserDTO.lastName : fetched_user.lastName,
                email = updateUserDTO.email != null ? updateUserDTO.email : fetched_user.email,
                passwordHash = passwordHash != null ? passwordHash : fetched_user.passwordHash
            };
            var updated_user = await _userRepo.UpdateUser(user);
            if (updated_user == null) return BadRequest(new {error="Something went wrong while updating user..."});
            return Ok(updated_user);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserController/UpdateUser: {ex.Message}");
            return BadRequest(new {error="Something went wrong while updating user..."});
        }
    }
    [HttpDelete("users/{id}")]
    public async Task<IActionResult> DeleteUser([FromRoute]Guid id){
        try
        {
            var deleted_user = await _userRepo.DeleteUser(id);
            if (deleted_user == null) return NotFound(new {error="User not found"});
            return Ok(new {message="User deleted successfully"});
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Exception in UserController/DeleteUser: {ex.Message}");
            return BadRequest(new {error="Something went wrong while deleting user..."});
        }
    }
}