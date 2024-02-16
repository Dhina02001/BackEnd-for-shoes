using EcomwebProjNew.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EcomwebProjNew.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserLoginContext _context;

        public RegisterController(UserLoginContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UsersLogin newUser)
        {
            // Check if the username already exists
            var existingUser = await _context.UserLogins.FirstOrDefaultAsync(u => u.Username == newUser.Username);

            if (existingUser != null)
            {
                // Username already exists, return BadRequest
                return BadRequest(new { message = "Username already exists" });
            }

            // Hash the password (you should use a proper password hashing algorithm)
            // For simplicity, this example just sets the password directly
            newUser.Password = newUser.Password; // Replace this with your actual password hashing logic

            // Add the new user to the database
            _context.UserLogins.Add(newUser);
            await _context.SaveChangesAsync();

            // Registration successful
            return Ok(new { message = "Registration successful" });
        }
    }
}
