using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eBookStore.Controllers
{
    public class RoleController : Controller
    {
        protected string apiLink = "http://localhost:5169/api/Role";

        public async Task<IActionResult> IndexAsync()
        {
            List<Role> roles = new List<Role>();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        roles = JsonConvert.DeserializeObject<List<Role>>(data);
                    }
                }
            }

            return View(roles);
        }

        public async Task<IActionResult> AddAsync()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Role role)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsJsonAsync(apiLink, role))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Add");
                    };
                }
            }
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.DeleteAsync(apiLink + "/" + id))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    };
                }
            }
        }

        public async Task<IActionResult> UpdateAsync(int id)
        {

            Role role = new Role();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        role = JsonConvert.DeserializeObject<Role>(data);
                    }
                }
            }
            return View(role);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(int id, Role role)
        {

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(apiLink + "/" + id, role))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    };
                }
            }
        }
    }
}
