using ApiPrpject1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace ApiPrpject1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly LeaveTypeContext _leavetypeContext;
        public UserController(LeaveTypeContext leavetypeContext)
        {
            _leavetypeContext = leavetypeContext;
        }

        [HttpPost("reg")]
        public IActionResult Register(Employee employee)
        {
            if (string.IsNullOrWhiteSpace(employee.Email) || string.IsNullOrWhiteSpace(employee.Password))
            {
                return BadRequest("Username and password are required");
            }


            var existingUser = _leavetypeContext.Employees.FirstOrDefault(u => u.Email == employee.Email);
            if (existingUser != null)
            {
                return BadRequest("Username already exists");
            }
            string Password = employee.Password;
            employee.Password = Password;


            _leavetypeContext.Employees.Add(employee);
            _leavetypeContext.SaveChanges();

            return Ok("Registration successful");
        }

        [HttpPost("login")]
        public IActionResult Login(Employee employee)
        {
            // Find the user by username and password
            var loggedInUser = _leavetypeContext.Employees.FirstOrDefault(u => u.Email == employee.Email && u.Password == employee.Password);

            if (loggedInUser == null)
            {
                return Unauthorized("Invalid credentials");
            }

            return Ok("Login successful");
        }

    }
}

