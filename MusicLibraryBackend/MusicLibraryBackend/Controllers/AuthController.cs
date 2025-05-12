using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MusicLibraryBackend.Data;
using MusicLibraryBackend.Models;
using System;
using System.Threading.Tasks;

namespace MusicLibraryBackend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly MusicLibraryContext _context;
        public AuthController(MusicLibraryContext context)
        {
            _context = context;
        }

        public class LoginRequest
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var user = await _context.UserModels.FirstOrDefaultAsync(u => u.Email == request.Email && u.Password == request.Password);
            if (user == null)
            {
                return Unauthorized(new { success = false, message = "Invalid email or password." });
            }
            return Ok(new { success = true, user });
        }

        public class SignupRequest
        {
            public string Name { get; set; }
            public string Gender { get; set; }
            public DateTime DateOfBirth { get; set; }
            public string Email { get; set; }
            public string Password { get; set; }
            public string Number { get; set; }
            public string ProfilePicturePath { get; set; }
        }

        [HttpPost("signup")]
        public async Task<IActionResult> Signup([FromBody] SignupRequest request)
        {
            if (await _context.UserModels.AnyAsync(u => u.Email == request.Email))
            {
                return Conflict(new { success = false, message = "A user with this email already exists." });
            }
            var newUser = new UserModel
            {
                Name = request.Name,
                Gender = request.Gender,
                DateOfBirth = request.DateOfBirth,
                Email = request.Email,
                Password = request.Password,
                Number = request.Number,
                ProfilePicturePath = request.ProfilePicturePath
            };
            _context.UserModels.Add(newUser);
            await _context.SaveChangesAsync();
            return Ok(new { success = true, user = newUser });
        }
    }
} 