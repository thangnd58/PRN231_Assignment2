using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Runtime.CompilerServices;

namespace eBookStore.Controllers
{
    public class UserController : Controller
    {
        protected string apiLink = "http://localhost:5169/api/User/Verify";

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }


        public IActionResult Logout()
        {
            HttpContext.Session.Remove("user");
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink + "?email=" + user.EmailAddress + "&password=" + user.Password))
                {
                    using (HttpContent content = res.Content)
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            string data = await content.ReadAsStringAsync();
                            var u = JsonConvert.DeserializeObject<User>(data);
                            HttpContext.Session.SetString("user", JsonConvert.SerializeObject(u));
                            return RedirectToAction("Index", "Home");
                        }
                        else
                        {
                            return RedirectToAction("Login", "User");
                        };
                    }
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            string api = "http://localhost:5169/api/User";
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsJsonAsync(api, user))
                {
                    using (HttpContent content = res.Content)
                    {
                        if (res.IsSuccessStatusCode)
                        {
                            return RedirectToAction("Login", "User");
                        }
                        else
                        {
                            return RedirectToAction("Register", "User");
                        };
                    }
                }
            }
        }
    }
}
