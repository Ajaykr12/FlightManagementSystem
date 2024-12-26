using Microsoft.AspNetCore.Mvc;
using FlightManagementSystem.Data;
using FlightManagementSystem.Models;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using System.Security.Principal;
using Microsoft.AspNetCore.Authorization;

namespace FlightManagementSystem.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string username, string password)
        {
            ClaimsIdentity identity = null;
            bool isAuthenticated = false;
            var hashedPassword = HashPassword(password);
            var user = _context.Users.FirstOrDefault(u => u.Username == username && u.Password == hashedPassword);

            if (user == null)
            {
                // Set session or authentication token
                ViewBag.Error = "Invalid credentials";
                return View();    
            }


            string UserId = Convert.ToString(user.Id);
            // Create the identity for the user
            identity = new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Sid, UserId)
        }, CookieAuthenticationDefaults.AuthenticationScheme);
            FlightManagementSystem.Models.Check.IsLoggedIn = true;
            var principal = new ClaimsPrincipal(identity);
            var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
            if (user.Role == "Admin" && FlightManagementSystem.Models.Check.IsLoggedIn)
            {
                return RedirectToAction("Index", "Flight");
            }
            else
                return RedirectToAction("UserIndex", "Flight");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                user.Password = HashPassword(user.Password);
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        public IActionResult Logout()
        {

            // Clear session or authentication token
            FlightManagementSystem.Models.Check.IsLoggedIn = false;
            var login = HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }

        private string HashPassword(string password)
        {
            using var sha256 = SHA256.Create();
            var bytes = Encoding.UTF8.GetBytes(password);
            var hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        [Authorize]
        public IActionResult Profile() {
            string? Username = User.FindFirst(claim => claim.Type == System.Security.Claims.ClaimTypes.Name)?.Value;
            if (Username !=null) { 
                var user = _context.Users.Where( u => u.Username == Username).FirstOrDefault();
                return View(user);
            }
            ViewBag.Error = "Invalid Profile";
            return View();
        }

        [Authorize]
        public IActionResult Edit(int id) {
            var user = _context.Users.Where( u => u.Id == id).FirstOrDefault();
            return View(user);
        }

        [Authorize]
        [HttpPost]
        public IActionResult Edit(User user)
        {
            ClaimsIdentity identity = null;
            var _user = _context.Users.Where(u => u.Id == user.Id).FirstOrDefault();
            if (_user!=null) {
                string UserId = Convert.ToString(user.Id);
                _user.Name = user.Name;
                _user.Username = user.Username;
                _user.Role = user.Role;
                _context.Users.Update(_user);
                _context.SaveChanges();
                // Create the identity for the user
                identity = new ClaimsIdentity(new[]
                {
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Role, user.Role),
            new Claim(ClaimTypes.Sid, UserId)
        }, CookieAuthenticationDefaults.AuthenticationScheme);
                return RedirectToAction("Profile");
            }
            ViewBag.Error = "Profile not edited successfully";
            return View();
        }
    }
}