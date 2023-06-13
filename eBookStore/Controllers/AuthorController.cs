using eBookStore.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace eBookStore.Controllers
{
    public class AuthorController : Controller
    {
        protected string apiLink = "http://localhost:5169/api/Author";

        public User VerifyUser()
        {
            User u = null;
            string json = HttpContext.Session.GetString("user");
            if (json != null) u = JsonConvert.DeserializeObject<User>(json);
            return u;
        }

        public async Task<IActionResult> IndexAsync()
        {
            List<Author> authors = new List<Author>();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        authors = JsonConvert.DeserializeObject<List<Author>>(data);
                    }
                }
            }
            ViewBag.ListAuthor = authors;

            return View();
        }

        public async Task<IActionResult> UpdateAsync(int id)
        {

            Author author = new Author();

            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.GetAsync(apiLink + "/" + id))
                {
                    using (HttpContent content = res.Content)
                    {
                        string data = await content.ReadAsStringAsync();
                        author = JsonConvert.DeserializeObject<Author>(data);
                    }
                }
            }
            return View(author);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateAsync(int id, Author author)
        {
            User u = VerifyUser();
            if (u == null || u.RoleId == null || u.RoleId != 1)
            {
                return RedirectToAction("Index");
            }
            using (HttpClient client = new HttpClient())
            {
                using (HttpResponseMessage res = await client.PutAsJsonAsync(apiLink + "/" + id, author))
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
        public async Task<IActionResult> AddAsync(Author author)
        {
            User u = VerifyUser();
            if (u == null || u.RoleId == null || u.RoleId != 1)
            {
                ViewBag.Message = "You are not permission";
                return View();
            } 
            if(author.AuthorId != 0)
            {
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage res = await client.PutAsJsonAsync(apiLink + "/" + author.AuthorId, author))
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
			} else
            {
				using (HttpClient client = new HttpClient())
				{
					using (HttpResponseMessage res = await client.PostAsJsonAsync(apiLink, author))
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
}
