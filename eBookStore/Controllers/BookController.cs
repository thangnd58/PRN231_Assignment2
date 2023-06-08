using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eBookStore.Controllers
{
    public class BookController : Controller
    {
        protected string apiLink = "http://localhost:5169/api/Book";

        public User VerifyUser()
        {
            User u = null;
            string json = HttpContext.Session.GetString("user");
            if (json != null) u = JsonConvert.DeserializeObject<User>(json);
            return u;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Book> books = new List<Book>();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        books = JsonConvert.DeserializeObject<List<Book>>(data);
                    }
                }
            }
            ViewBag.ListBook = books;

            List<Publisher> publishers = new List<Publisher>();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync("http://localhost:5169/api/Publisher"))
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

            Book book = new Book();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        book = JsonConvert.DeserializeObject<Book>(data);
                    }
                }
            }
			List<Publisher> publishers = new List<Publisher>();

			using (HttpClient client = new HttpClient())
			{
				using (HttpResponseMessage res = await client.GetAsync("http://localhost:5169/api/Publisher"))
				{
					using (HttpContent content = res.Content)
					{
						string data = await content.ReadAsStringAsync();
						publishers = JsonConvert.DeserializeObject<List<Publisher>>(data);
					}
				}
			}
			ViewBag.ListPublisher = publishers;
			return View(book);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(int id, Book book)
        {
            User u = VerifyUser();
            if (u == null || u.RoleId == null || u.RoleId != 1)
            {
                return RedirectToAction("Index");
            }
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(apiLink + "/" + id, book))
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
        public async Task<IActionResult> AddAsync(Book book)
        {
            User u = VerifyUser();
            if (u == null || u.RoleId == null || u.RoleId != 1)
            {
                return RedirectToAction("Index");
            }
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PostAsJsonAsync(apiLink, book))
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
