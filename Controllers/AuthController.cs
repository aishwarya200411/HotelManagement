using Microsoft.AspNetCore.Mvc;
using HotelManagement.Data;
using HotelManagement.Models;
using System.Linq;

namespace HotelBooking.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Register API
        [HttpPost("register")]
        public IActionResult Register(User user)
        {
            // Check if email already exists
            var existingUser = _context.Users
                .FirstOrDefault(u => u.EmailId == user.EmailId);

            if (existingUser != null)
                return BadRequest("Email already exists");

            // Save user
            _context.Users.Add(user);
            _context.SaveChanges();

            return Ok("User Registered Successfully");
        }

        // ✅ Login API
        [HttpPost("login")]
        public IActionResult Login(LoginDto login)
        {
            var user = _context.Users
                .FirstOrDefault(u => u.EmailId == login.Email && u.Password == login.Password);

            if (user == null)
                return Unauthorized("Invalid Email or Password");

            return Ok(user);
        }
    }
}