using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using Music_Library_System.Models;
using System.Text.Json;

namespace Music_Library_System.Controllers
{
    public class AccountController : Controller
    {
        private const string SessionKey = "UserSession";
        // In-memory user store
        private static List<UserModel> Users = new List<UserModel>();
        private static bool DummyUserAdded = false;

        private void EnsureDummyUser()
        {
            if (!DummyUserAdded)
            {
                Users.Add(new UserModel
                {
                    Name = "Test User",
                    Gender = "Male",
                    DateOfBirth = new DateTime(2000, 1, 1),
                    Email = "test@example.com",
                    Password = "password123",
                    Number = "1234567890",
                    ProfilePicturePath = null
                });
                DummyUserAdded = true;
            }
        }

        private UserSession GetCurrentSession()
        {
            var sessionJson = HttpContext.Session.GetString(SessionKey);
            return sessionJson == null ? null : JsonSerializer.Deserialize<UserSession>(sessionJson);
        }

        private void SetCurrentSession(UserSession session)
        {
            var sessionJson = JsonSerializer.Serialize(session);
            HttpContext.Session.SetString(SessionKey, sessionJson);
        }

        [HttpGet]
        public IActionResult Register()
        {
            EnsureDummyUser();
            return View();
        }

        [HttpPost]
        public IActionResult Register(string Name, string Gender, DateTime DateOfBirth, string Email, string Password, string Number, IFormFile ProfilePicture)
        {
            EnsureDummyUser();
            if (Users.Any(u => u.Email.Equals(Email, StringComparison.OrdinalIgnoreCase)))
            {
                ViewBag.Error = "A user with this email already exists.";
                return View();
            }
            string profilePicPath = null;
            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                // For demo, just use file name (not saving to disk)
                profilePicPath = ProfilePicture.FileName;
            }
            var newUser = new UserModel
            {
                Name = Name,
                Gender = Gender,
                DateOfBirth = DateOfBirth,
                Email = Email,
                Password = Password,
                Number = Number,
                ProfilePicturePath = profilePicPath
            };
            Users.Add(newUser);
            ViewBag.Message = "Registration successful! You can now sign in.";
            return View();
        }

        [HttpGet]
        public IActionResult Login()
        {
            EnsureDummyUser();
            return View();
        }

        [HttpPost]
        public IActionResult Login(string Email, string Password, bool RememberMe)
        {
            EnsureDummyUser();
            var user = Users.FirstOrDefault(u => u.Email.Equals(Email, StringComparison.OrdinalIgnoreCase) && u.Password == Password);
            if (user == null)
            {
                ViewBag.Error = "Invalid account details.";
                return View();
            }
            
            // Create and store session
            var session = UserSession.FromUserModel(user);
            SetCurrentSession(session);
            
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKey);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public IActionResult Profile()
        {
            var session = GetCurrentSession();
            if (session == null || !session.IsLoggedIn)
            {
                return RedirectToAction("Login");
            }
            return View(session);
        }
    }
} 