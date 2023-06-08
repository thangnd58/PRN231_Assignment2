using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eBookStore.Controllers
{
    public class PublisherController : Controller
    {
        protected string apiLink = "http://localhost:5169/api/Publisher";

        public User VerifyUser()
        {
            User u = null;
            string json = HttpContext.Session.GetString("user");
            if (json != null) u = JsonConvert.DeserializeObject<User>(json);
            return u;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Publisher> publishers = new List<Publisher>();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        publishers = JsonConvert.DeserializeObject<List<Publisher>>(data);
                    }
                }
            }
            ViewBag.ListPublisher = publishers;

            return View();
        }

        public async Task<IActionResult> UpdateAsync(int id)
        {

            Publisher publisher = new Publisher();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        publisher = JsonConvert.DeserializeObject<Publisher>(data);
                    }
                }
            }
            return View(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(int id, Publisher publisher)
        {
            User u = VerifyUser();
            if (u == null || u.RoleId == null || u.RoleId != 1)
            {
                return RedirectToAction("Index");
            }
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(apiLink + "/" + id, publisher))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return BadRequest();
                    };
                }
            }
        }

        public async Task<IActionResult> DeleteAsync(int id)
        {
            User u = VerifyUser();
            if (u == null || u.RoleId == null || u.RoleId != 1)
            {
                return RedirectToAction("Index");
            }
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
                        return BadRequest();
                    };
                }
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(Publisher publisher)
        {
            User u = VerifyUser();
            if (u == null || u.RoleId == null || u.RoleId != 1)
            {
                return RedirectToAction("Index");
            }
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsJsonAsync(apiLink, publisher))
                {
                    if (res.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        return BadRequest();
                    };
                }
            }
        }
    }
}
