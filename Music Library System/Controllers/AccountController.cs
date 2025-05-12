using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using Music_Library_System.Models;
using System.Text.Json;

namespace Music_Library_System.Controllers
{
    public class AccountController : Controller
    {
        private const string SessionKey = "UserSession";
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _apiBaseUrl = "http://localhost:5212";

        public AccountController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
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
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string Name, string Gender, DateTime DateOfBirth, string Email, string Password, string Number, IFormFile ProfilePicture)
        {
            string profilePicPath = null;
            if (ProfilePicture != null && ProfilePicture.Length > 0)
            {
                // For demo, just use file name (not saving to disk)
                profilePicPath = ProfilePicture.FileName;
            }
            var signupData = new
            {
                name = Name,
                gender = Gender,
                dateOfBirth = DateOfBirth,
                email = Email,
                password = Password,
                number = Number,
                profilePicturePath = profilePicPath
            };
            // Debug: print outgoing JSON
            Console.WriteLine("Signup JSON: " + System.Text.Json.JsonSerializer.Serialize(signupData));
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(_apiBaseUrl + "/api/auth/signup", signupData);
            var result = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API Response: " + result);
            var json = System.Text.Json.JsonDocument.Parse(result).RootElement;
            if (response.IsSuccessStatusCode && json.GetProperty("success").GetBoolean())
            {
                // Store user in session
                var user = json.GetProperty("user").ToString();
                var userSession = System.Text.Json.JsonSerializer.Deserialize<UserSession>(user);
                SetCurrentSession(userSession);
                ViewBag.Message = "Registration successful! You can now sign in.";
                return RedirectToAction("Login");
            }
            else
            {
                ViewBag.Error = json.TryGetProperty("message", out var msg) ? msg.GetString() : "Signup failed.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string Email, string Password, bool RememberMe)
        {
            var loginData = new { email = Email, password = Password };
            var client = _httpClientFactory.CreateClient();
            var response = await client.PostAsJsonAsync(_apiBaseUrl + "/api/auth/login", loginData);
            var result = await response.Content.ReadAsStringAsync();
            var json = System.Text.Json.JsonDocument.Parse(result).RootElement;
            if (response.IsSuccessStatusCode && json.GetProperty("success").GetBoolean())
            {
                // Store user in session
                var user = json.GetProperty("user").ToString();
                var userSession = System.Text.Json.JsonSerializer.Deserialize<UserSession>(user);
                userSession.IsLoggedIn = true; // Ensure IsLoggedIn is set
                SetCurrentSession(userSession);
                Console.WriteLine("Session set after login: " + HttpContext.Session.GetString(SessionKey));
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = json.TryGetProperty("message", out var msg) ? msg.GetString() : "Login failed.";
                return View();
            }
        }

        [HttpGet]
        public IActionResult Logout()
        {
            HttpContext.Session.Remove(SessionKey);
            return RedirectToAction("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Profile()
        {
            var sessionJson = HttpContext.Session.GetString(SessionKey);
            Console.WriteLine("Session on profile: " + sessionJson);
            var session = GetCurrentSession();
            if (session == null || !session.IsLoggedIn)
            {
                return RedirectToAction("Login");
            }

            // Fetch personal information from backend API
            var client = _httpClientFactory.CreateClient();
            PersonalInformation personalInfo = null;
            try
            {
                var response = await client.GetAsync($"{_apiBaseUrl}/api/PersonalInformation/{session.Id}");
                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    personalInfo = System.Text.Json.JsonSerializer.Deserialize<PersonalInformation>(json, new System.Text.Json.JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error fetching personal info: " + ex.Message);
            }
            ViewBag.PersonalInfo = personalInfo;
            return View(session);
        }

        // GET: Account/Edit
        [HttpGet]
        public IActionResult Edit()
        {
            var session = GetCurrentSession();
            if (session == null || !session.IsLoggedIn)
            {
                return RedirectToAction("Login");
            }
            return View(session);
        }

        // POST: Account/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UserSession updatedSession)
        {
            if (ModelState.IsValid)
            {
                updatedSession.IsLoggedIn = true;
                SetCurrentSession(updatedSession);
                return RedirectToAction("Profile");
            }
            return View(updatedSession);
        }
    }
} 