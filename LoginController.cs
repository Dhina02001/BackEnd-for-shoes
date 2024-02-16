using EcomwebProjNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomwebProjNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly UserLoginContext _context;

        public LoginController(UserLoginContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsersLogin request)
        {
            var user = await _context.UserLogins.FirstOrDefaultAsync(u => u.Username == request.Username);

            if (user == null)
            {
                // Log the username that was not found in the database
                Console.WriteLine($"User '{request.Username}' not found in the database.");
                return BadRequest(new { message = "Invalid username or password" });
            }

            if (!VerifyPassword(user, request.Password))
            {
                // Log the username for which the password verification failed
                Console.WriteLine($"Invalid password for user '{request.Username}'.");
                return BadRequest(new { message = "Invalid username or password" });
            }

            // Login successful
            return Ok(new { message = "Login successful" });
        }


        // Dummy method to verify password
        private bool VerifyPassword(UsersLogin user, string password)
        {
            // Replace this with your actual password verification logic
            return user.Password == password;
        }
    }
}